using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Sistema_de_Doacao_de_Sangue.Core.Interfaces;
using Sistema_de_Doacao_de_Sangue.Core.Interfaces.Services;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;
using Sistema_de_Doacao_de_Sangue.Core.Services;
using Sistema_de_Doacao_de_Sangue.Core.Utils;
using Sistema_de_Doacao_de_Sangue.Infrastructure.Persistence.Repositories;

namespace Sistema_de_Doacao_de_Sangue.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUnityOfWork, UnityOfWork>();

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddScoped<IDoadoresRepository, DoadoresRepository>();

            services.AddScoped<IDoacaoRepository, DoacaoRepository>();

            services.AddScoped<IEstoqueRepository, EstoqueRepository>();

            services.AddScoped<IRelatoriosRepository, RelatoriosRepository>();

            services.AddScoped<IPdfGenerator, PdfGenerator>();

            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped<IUserRepository, UserRepository>();

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }
    }
}