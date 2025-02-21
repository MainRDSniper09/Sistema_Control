using Microsoft.Extensions.DependencyInjection;
using SFRepository.DB;
using SFRepository.Implementation;
using SFRepository.Interfaces;

namespace SFRepository
{
    public static class DependencyInjection
    {
        public static void RegisterRepositoryDependencies (this IServiceCollection services)
        {
            services.AddSingleton<Conexion>();
            services.AddTransient<IMedidaRepository, MedidaRepository>();
            services.AddTransient<ICategoriaRepository, CategoriaRepository>();
        }
    }
}
