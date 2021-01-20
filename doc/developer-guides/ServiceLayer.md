# Service Layer

Nachfolgend werden einzelne Besonderheiten des Service Layer erläutert. Die zugehörigen Projekte beginnen mit `FHTW.CodeRunner.Services`.

## AutoMapper

Für das Mapping wird AutoMapper verwendet. Die Mapping-Profile befinden sich dabei im Ordner `AutoMapper`. Genauso haben wir auch entschieden einzelne Konvertierungen über den AutoMapper zu lösen. Dafür wurde der Ordner `Converters` angelegt und hier wurden einzelne AutoMapper-Custom-Converters erzeugt. Zum Beispiel passiert hier auch das Mapping von den Moodle Quiz Entities auf unsere eigenen Entities.

## Basic Authentication

Als Authentifizierung wurde hier sehr simpel Basic Authentication eingesetzt. Dabei wurde vorerst keine andere Authentfizierung gewählt, da dieses in einem späteren Stadium mit LDAP verknüpft werden könnte.

## Swagger

Damit eine gute Kommunikation mit den Frontend-Entwicklern sichergestellt ist, haben wir uns auch entschieden Swagger zu verwenden. Die Konfiguration dazu befinden sich in `Startup.cs` und sieht wie folgt aus:

```csharp
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
        c.AddSecurityDefinition("Basic", new OpenApiSecurityScheme
        {
            Description = "Basic auth added to authorization header",
            Name = "Authorization",
            In = ParameterLocation.Header,
            Scheme = "basic",
            Type = SecuritySchemeType.Http,
        });

        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Basic" },
                },
                new List<string>()
            },
        });
    });

services.AddSwaggerGenNewtonsoftSupport();
```

Hier ist zu beachten, dass die DataContracts von den DTOs verwendet werden. Genauso wird das Swagger UI immer neu generiert und entspricht daher auch stets der vorhandenen API. Weiters ist zu erwähnen, dass hier auch Authorisierung hinzugefügt wurde. Da im Frontend aber die Passwörter mit sha512 gesichert werden, muss auch im Swagger UI für das Passwort der Hashwert eingegeben werden.

## ClientApp

In diesem Ordner befindet sich die Frontend Lösung, welche mit Angular umgesetzt wurde. Dies könnte beispielsweise sehr einfach mit einem anderen Framework ausgetauscht werden. Hierzu müssten nur kleine Anpassungen in `Startup.cs` und `FHTW.CodeRunner.Services.csproj` gemacht werden.
