using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Simplerjiang.AspnetCoreEmailSender;

namespace AspnetCoreTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

        public static EmailSettings EmailSettings { get; set; } = Simplerjiang.ConfigJsonSave.JsonWorker.Read<EmailSettings>(System.IO.Path.Combine(Environment.CurrentDirectory,"emailSettings.json"));
    }
}
