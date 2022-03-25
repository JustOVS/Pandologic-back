using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Autofac.Extensions.DependencyInjection;

namespace Pandologic.API
{
  public class Program
  {
    public static void Main(string[] args)
    {
      CreateHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateHostBuilder(string[] args) =>
      WebHost.CreateDefaultBuilder(args)
        .UseConfiguration(new ConfigurationBuilder()
          .AddJsonFile("appSettings.json")
          .Build())
        .UseStartup<Startup>()
        .ConfigureServices(services => services.AddAutofac());
  }
}