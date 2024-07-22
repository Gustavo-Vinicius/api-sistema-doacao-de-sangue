using System.Reflection;
using Microsoft.OpenApi.Models;

namespace Sistema_de_Doacao_de_Sangue.API.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)
        {
            services.AddSwaggerGen(x =>
        {
       // Adiciona o arquivo XML para a própria assembly
       var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
       var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
       if (File.Exists(xmlPath))
       {
           x.IncludeXmlComments(xmlPath);
       }

       // Adiciona arquivos XML para assemblies referenciadas
       var currentAssembly = Assembly.GetExecutingAssembly();
       var xmlDocs = currentAssembly.GetReferencedAssemblies()
           .Union(new AssemblyName[] { currentAssembly.GetName() })
           .Select(a => Path.Combine(AppContext.BaseDirectory, $"{a.Name}.xml"))
           .Where(f => File.Exists(f))
           .ToArray();

       Array.ForEach(xmlDocs, d =>
       {
           x.IncludeXmlComments(d);
       });

       // Configurações adicionais de segurança para JWT
       x.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
       {
           In = ParameterLocation.Header,
           Description = "Insira o token JWT no campo de texto a seguir. Exemplo: Bearer {token}",
           Name = "Authorization",
           Type = SecuritySchemeType.ApiKey,
           Scheme = "Bearer"
       });

       x.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                new string[] {}
            }
       });
   });
        }
    }
}