using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace OnlineDrinkOrderSystem
{
    public class Program
    {
        //private static readonly IOptions<Models.ConnectionStrings> connectionString;
        public static void Main(string[] args)
        {
            //        var builder = new ConfigurationBuilder()
            //.SetBasePath(Directory.GetCurrentDirectory())
            //.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            //        IConfigurationRoot configuration = builder.Build();

            //        Console.WriteLine("ConnectionStrings");
            //        Console.WriteLine(configuration.GetConnectionString("Database"))


            //Console.WriteLine(Program.connectionString.Value.Database);
            //Console.WriteLine(Program.connectionString.Value.Server);
            //Console.WriteLine(Program.connectionString.Value.Uid);
            //Console.WriteLine(Program.connectionString.Value.Pwd);

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
