using DesktopApp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Data;

namespace WinDesktopApp
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Create a service collection and configure the DbContext
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Build the service provider to get the CarAppContext
            using (var serviceProvider = serviceCollection.BuildServiceProvider())
            {
                // Resolve CarAppContext
                using (var context = serviceProvider.GetRequiredService<CarAppContext>())
                {
                    // Apply pending migrations (this will create the database if it doesn't exist)
                    context.Database.Migrate();
                    //context.Database.EnsureCreated();

                    // Seed the admin if the Administrators table is empty
                    //context.SeedAdminIfTableIsEmpty();
                }
            }

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new ControlPage());
        }

        // Configure the services, including DbContext
        private static void ConfigureServices(IServiceCollection services)
        {
            // Add DbContext with your connection string
            services.AddDbContext<CarAppContext>(options =>
                options.UseSqlServer(Configuration.ConnectionString));
        }
    }
}
