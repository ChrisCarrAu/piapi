using Microsoft.Extensions.DependencyInjection;
using SimpleLed.Services;

namespace SimpleLed
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create service collection and configure our services
            var services = ConfigureServices();
            
            // Generate a provider
            var serviceProvider = services.BuildServiceProvider();
   
            // Kick off our actual code
            serviceProvider.GetService<Startup>().Run();
        }

        private static IServiceCollection ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<ITestService, TestService>();
            
            // IMPORTANT! Register our application entry point
            services.AddTransient<Startup>();

            return services;
        }
    }
}
