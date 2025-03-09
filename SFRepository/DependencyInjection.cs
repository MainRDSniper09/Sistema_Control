using Microsoft.Extensions.DependencyInjection;
using SFRepository.DB;
using SFRepository.Entities;
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
            services.AddTransient<IProductoRepository, ProductoRepository>();
            services.AddTransient<INegocioRepository, NegocioRepository>();
            services.AddTransient<IRolRepository, RolRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IVentaRepository, VentaRepository>();
            services.AddTransient<IMenuRolRepository, MenuRolRepository>();

        }
    }
}
