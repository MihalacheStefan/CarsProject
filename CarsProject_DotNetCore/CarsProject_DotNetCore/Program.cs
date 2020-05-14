using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;


namespace CarsProject_DotNetCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            //using (var scope = host.Services.CreateScope())
            //{ }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
