using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using VotoWinForms.Contract.Repository;
using VotoWinForms.Contract.Service;
using VotoWinForms.Forms;
using VotoWinForms.Repository;
using VotoWinForms.Service;

namespace VotoWinForms
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var host = CreateHostBuilder().Build();

            ApplicationConfiguration.Initialize();

            var form = host.Services.GetRequiredService<FormUrna>();
            Application.Run(form);
        }

        static IHostBuilder CreateHostBuilder(){

            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    // Repositórios
                    services.AddScoped<ICandidatoRepository, CandidatoRepository>();
                    services.AddScoped<IVotoRepository, VotoRepository>();

                    // Serviços
                    services.AddScoped<IVotoService, VotoService>();

                    // Formulários
                    services.AddScoped<FormUrna>();
                }); ;
        }
            
    }
}