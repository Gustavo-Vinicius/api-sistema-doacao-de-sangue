using System.Reflection;
using Microsoft.OpenApi.Models;

namespace Sistema_de_Doacao_de_Sangue.API.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                var filePath = Path.Combine(AppContext.BaseDirectory, "Sistema-de-Doacao-de-Sangue.API.xml");
                c.IncludeXmlComments(filePath);
                
                var currentAssembly = Assembly.GetExecutingAssembly();
                var xmlDocs = currentAssembly
                    .GetReferencedAssemblies()
                    .Union(new AssemblyName[] { currentAssembly.GetName() })
                    .Select(a =>
                        Path.Combine(
                            Path.GetDirectoryName(currentAssembly.Location),
                            $"{a.Name}.xml"
                        )
                    )
                    .Where(f => System.IO.File.Exists(f))
                    .ToArray();

                Array.ForEach(xmlDocs, (d) => c.IncludeXmlComments(d));

                    c.SwaggerDoc("v1",
                        new OpenApiInfo
                    {
                        Title = "Sistema de Doação de Sangue - V1",
                        Version = "v1"
                    }
                 );

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Token",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header usando o esquema Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string [] {}
        }
                });
                c.IncludeXmlComments(filePath);
            });

        }

    }
}