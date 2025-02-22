using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SFPresentation.Formularios;
using SFRepository;
using SFRepository.Implementation;
using SFRepository.Interfaces;
using SFServices;
using SFServices.Implementation;
using SFServices.Interfaces;

namespace SFPresentation
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            var host = CreateHostBuilder().Build(); // Conexion a nuestra cadena de conexion
            var formService = host.Services.GetRequiredService<frmProducto>(); // Crear nuestro servicio 
            
            
            Application.Run(formService);
        }

        // Utilizar un componente de nuestro paquete hosting instalado
        // Si o si se necesita cargar la configuracion de nuestra aplicacion creada en JSOn
        static IHostBuilder CreateHostBuilder() => Host.CreateDefaultBuilder().ConfigureAppConfiguration((contex,config)=> {
            config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        }).ConfigureServices((context, services) => {


            services.RegisterRepositoryDependencies();
            services.RegisterServiceDependencies();

            services.AddTransient<frmCategoria>();
            services.AddTransient<frmProducto>();
            
        });
    }
}