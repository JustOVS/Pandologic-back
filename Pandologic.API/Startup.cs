using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Insight.Database;
using System;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using Autofac;
using Pandologic.Repositories;
using AutoMapper;
using Pandologic.API.Mappings;
using Pandologic.Logic.JobStatistics;
using Pandologic.API.Infrastructure.Middleware;

namespace Pandologic.API
{
  public class Startup
  {
    private readonly IConfiguration _configuration;
    private bool IsSwaggerEnabled => _configuration["EnableSwagger"].Equals("true", StringComparison.OrdinalIgnoreCase);

    public Startup(IConfiguration configuration)
    {
      _configuration = configuration;
    }


    public void ConfigureServices(IServiceCollection services)
    {
      var mapperConfig = new MapperConfiguration(mc =>
      {
        mc.AddProfile(new JobViewsStatisticModelMapping());
        mc.AddProfile(new JobViewsStatisticMapping());
      });

      var mapper = mapperConfig.CreateMapper();
      services.AddSingleton(mapper);

      services.AddSwaggerGen(c =>
      {
        c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pandologic API", Version = "v1" });
      });
      services.AddCors();
      services.AddControllers();

      DbProviderFactories.RegisterFactory(DbConnectionSettings.ProviderName, SqlClientFactory.Instance);
      SqlInsightDbProvider.RegisterProvider();
    }

    public void ConfigureContainer(ContainerBuilder builder)
    {
      builder.RegisterModule(new AutofacModule(_configuration));
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      app.UseMiddleware<ErrorHandlingMiddleware>();

      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }

      if (IsSwaggerEnabled)
      {
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("v1/swagger.json", "Pandologic API V1"));
      }

      app.UseRouting();
      app.UseCors(options => options.AllowAnyOrigin());
      app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
  }
}