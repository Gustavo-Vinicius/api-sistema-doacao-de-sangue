using Sistema_de_Doacao_de_Sangue.Core.Interfaces;
using Sistema_de_Doacao_de_Sangue.Core.Repositories;
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
        }
    }
}