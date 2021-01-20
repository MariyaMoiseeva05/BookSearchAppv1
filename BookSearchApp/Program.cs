using BLL.Interfaces;
using BLL.Util;
using BookSearchApp.Util;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Ninject;
using DAL.Entities;
using Microsoft.Extensions.DependencyInjection;
using DAL.Data;
using System;
using Microsoft.Extensions.Logging;

namespace BookSearchApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context =
                   services.GetRequiredService<BookSearchContext>();
                    DbInitializer.Initialize(context);

                }
                catch (Exception ex)
                {
                    var logger =
                   services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Произошла ошибка при создании БД.");
                }
            }
            host.Run();


            CreateHostBuilder(args).Build().Run();

            var kernel = new StandardKernel(new NinjectRegistration(), new ServiceModule("BookSearchContext"));
            IDbCRUD crudServ = kernel.Get<IDbCRUD>();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureLogging((hostingContext, logging) =>
            {
                logging.AddConfiguration(hostingContext.Configuration.GetSection("Logging"));
                logging.AddConsole();
                logging.AddDebug();
                logging.AddEventSourceLogger();
            })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.UseIISIntegration();
                });

    }
}
