using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace OnlineDrinkOrderSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
    //        var builder = new ConfigurationBuilder()
    //.SetBasePath(Directory.GetCurrentDirectory())
    //.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

    //        IConfigurationRoot configuration = builder.Build();

    //        Console.WriteLine("ConnectionStrings");
    //        Console.WriteLine(configuration.GetConnectionString("Host"));
    //        Console.WriteLine(configuration.GetConnectionString("Port"));
    //        Console.WriteLine(configuration.GetConnectionString("User"));
    //        Console.WriteLine(configuration.GetConnectionString("Password"));

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
