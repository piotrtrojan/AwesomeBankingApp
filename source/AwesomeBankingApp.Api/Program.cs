using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace AwesomeBankingApp.Api
{
    /// <summary>
    /// Main AwesomeBankingApp.Api class.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// AwesomeBankingApp.Api startup method.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Composes HostBuilder that will host the application.
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
