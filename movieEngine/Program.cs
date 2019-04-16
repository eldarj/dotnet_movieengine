using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using movieEngine.Data;
using movieEngine.Web.Utils;

namespace movieEngine
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webHost = CreateWebHostBuilder(args).Build(); 

            // after getting the host builder; try to get the services scope, in which our MyDbContext is - to be passed to our DbSeeder
            using (var scope = webHost.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                DbSeeder.Initialize(services);
            }

            webHost.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
