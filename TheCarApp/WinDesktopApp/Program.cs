using System;
using System.Windows.Forms;
using WinDesktopApp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Data;
using WinDesktopApp.Forms;

namespace WinDesktopApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            try
            {
                using (var serviceProvider = serviceCollection.BuildServiceProvider())
                {
                    using (var context = serviceProvider.GetRequiredService<CarAppContext>())
                    {
                        // Apply migrations if needed
                        context.Database.Migrate();
                    }
                }

                // Initialize the application and run the main form
                ApplicationConfiguration.Initialize();
                //MessageBox.Show("Worked!");
                Application.Run(new ControlPage());

            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred during startup: {ex.Message}");
            }
            finally
            {
                
            }
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<CarAppContext>(options =>
                options.UseSqlServer(Configuration.ConnectionString));
        }
    }
}
