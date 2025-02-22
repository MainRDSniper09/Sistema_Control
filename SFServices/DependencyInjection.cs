
using Microsoft.Extensions.DependencyInjection;
using SFServices.Implementation;
using SFServices.Interfaces;

namespace SFServices
{
    public static class DependencyInjection
    {
        public static void RegisterServiceDependencies(this IServiceCollection services)
        {
            services.AddTransient<IMedidaService, MedidaService>();
            services.AddTransient<ICategoriaService, CategoriaService>();
            services.AddTransient<IProductoService, ProductoService>();
        }
    }
}
