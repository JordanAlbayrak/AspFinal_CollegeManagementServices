using College_Management_Services.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace College_Management_Services
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build(); //create an instance of host
            using (var scope = host.Services.CreateScope()) //create the scope of execution through dependency injection
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<College_Management_ServicesContext>(); //Get services from DB context and bind it to DB through migration
                    context.Database.Migrate(); // execute the migration code to create appropriate tables and columns according to context.
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred creating the DB");
                }
            }
            host.Run(); // run the host instance
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
