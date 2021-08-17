using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace ShopOnline.BackEndApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            //.UseSetting("https_port", "443");
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                    //.UseSetting("https_port", "443");
                });
    }
}
