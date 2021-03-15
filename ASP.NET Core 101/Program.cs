using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using ASP.NET_Core_101.Models;

namespace ASP.NET_Core_101
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //InitializeDB();
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        static void InitializeDB()
        {
            using var db = new AppDBContext();

            var x = JsonSerializer.Deserialize<Product[]>(
                File.OpenText(
                        @"C:\Users\andre\Documents\Programming\Work\Qubiz\ASP.NET Core 101\wwwroot\data\products.json")
                    .ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            foreach (var product in x.ToList())
                db.Products.Add(product);
            db.SaveChanges();

            db.Dispose();
        }
    }
}
