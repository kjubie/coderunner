// <copyright file="Startup.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using AutoMapper;
using FHTW.CodeRunner.BusinessLogic;
using FHTW.CodeRunner.BusinessLogic.Interfaces;
using FHTW.CodeRunner.DataAccess.Entities;
using FHTW.CodeRunner.DataAccess.Interfaces;
using FHTW.CodeRunner.DataAccess.Sql;
using FHTW.CodeRunner.ExportService;
using FHTW.CodeRunner.ExportService.Interfaces;
using FHTW.CodeRunner.Services.Helpers;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace FHTW.CodeRunner.Services
{
    /// <summary>
    /// Class to configure the startup of the Webserver.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        private readonly IWebHostEnvironment hostingEnv;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="env">The hosting environment.</param>
        /// <param name="configuration">The parameters for configuration.</param>
        public Startup(IWebHostEnvironment env, IConfiguration configuration)
        {
            this.hostingEnv = env;
            this.Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration of the startup.
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The collection for the sevices.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            string connection;

            if (Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true")
            {
                Debug.WriteLine("Running inside of Docker");
                connection = this.Configuration.GetConnectionString("DockerConnection");
            }
            else
            {
                Debug.WriteLine("Running outside of Docker");
                connection = this.Configuration.GetConnectionString("DefaultConnection");
            }

            services.AddDbContext<CodeRunnerContext>(
                options =>
                {
                    options.UseNpgsql(connection, b => b.MigrationsAssembly("FHTW.CodeRunner.Migrations"));
                });

            services
                .AddMvc(options =>
                {
                    options.InputFormatters.RemoveType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonInputFormatter>();
                    options.OutputFormatters.RemoveType<Microsoft.AspNetCore.Mvc.Formatters.SystemTextJsonOutputFormatter>();
                })
                .AddNewtonsoftJson(opts =>
                {
                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    opts.SerializerSettings.Converters.Add(new StringEnumConverter(new CamelCaseNamingStrategy()));
                    opts.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    opts.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
                })
                .AddXmlSerializerFormatters();

            services.AddAutoMapper(typeof(Startup));

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddCors();
            services.AddControllers();

            services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo
                    {
                        Version = "v1",
                        Title = "FHTW CodeRunner",
                        Description = "API for managing CodeRunner Actions (ASP.NET 5)",
                        Contact = new OpenApiContact()
                        {
                            Name = "FHTW",
                            Url = new Uri("http://www.technikum-wien.at/"),
                            Email = string.Empty,
                        },
                    });
                    c.CustomSchemaIds(type => type.FullName);
                    c.IncludeXmlComments($"{AppContext.BaseDirectory}{Path.DirectorySeparatorChar}{this.hostingEnv.ApplicationName}.xml");

                    // Include DataAnnotation attributes on Controller Action parameters as Swagger validation rules (e.g required, pattern, ..)
                    // Use [ValidateModelState] on Actions to actually validate it in C# as well!
                    // c.OperationFilter<GeneratePathParamsValidationFilter>();
                });

            services.AddSwaggerGenNewtonsoftSupport();

            // configure basic authentication
            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            services.AddTransient<IExerciseLogic, ExerciseLogic>();
            services.AddTransient<IUserLogic, UserLogic>();
            services.AddTransient<IExportLogic, ExportLogic>();
            services.AddTransient<IImportLogic, ImportLogic>();

            services.AddTransient<IExerciseRepository, ExerciseRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUIRepository, UIRepository>();

            services.AddTransient<IMoodleXmlService, MoodleXmlService>();

            services.AddLogging(configuration =>
            {
                configuration.AddDebug();
                configuration.AddConsole();
            });
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The builder for the application.</param>
        /// <param name="env">The hosting environment.</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<CodeRunnerContext>();

                // context.Database.EnsureDeleted();

                // context.Database.EnsureCreated();
                if (!context.AllMigrationsApplied())
                {
                    context.Database.Migrate();
                }

                context.EnsureSeeded();

                // TEST
                IExerciseRepository rep = new ExerciseRepository(context);
                ICollectionRepository repC = new CollectionRepository(context);

                var list = rep.GetMinimalList();
                var instance = rep.GetExerciseInstance(1, "C++", "English", 3);
                var ce = repC.GetExercisesInstances(1);
                var ci = repC.GetCollectionInstance(1);
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
