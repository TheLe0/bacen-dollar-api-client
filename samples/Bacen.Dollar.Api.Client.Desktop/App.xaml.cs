using Bacen.Dollar.Api.Client.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace Bacen.Dollar.Api.Client.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ServiceProvider serviceProvider;
        public App()
        {
            ServiceCollection services = new();
            ConfigureServices(services);
            serviceProvider = services.BuildServiceProvider();
        }
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddBacenDollarApiClient();
            services.AddSingleton<MainWindow>();
        }
        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = serviceProvider.GetService<MainWindow>();
            
            mainWindow?.Show();
        }
    }
}
