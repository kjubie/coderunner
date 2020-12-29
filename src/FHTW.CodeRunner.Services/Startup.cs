// <copyright file="Startup.cs" company="FHTW CodeRunner">
// Copyright (c) FHTW CodeRunner. All Rights Reserved.
// </copyright>

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
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
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace FHTW.CodeRunner.Services
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">th configuration.</param>
        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

                //TEST

                IExerciseRepository rep = new ExerciseRepository(context);
                ICollectionRepository repC = new CollectionRepository(context);

                var list = rep.GetMinimalList();
                var instance = rep.GetExerciseInstance(1, "C++", "English");
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
