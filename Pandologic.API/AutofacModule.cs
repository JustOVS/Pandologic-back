using Autofac;
using Microsoft.Extensions.Configuration;
using Pandologic.Logic.JobStatistics;
using Pandologic.Repositories;

namespace Pandologic.API
{
  public class AutofacModule : Module
  {
    private readonly IConfiguration _configuration;

    public AutofacModule(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    protected override void Load(ContainerBuilder builder)
    {
      builder.Register(c => new DbConnectionSettings { ConnectionString = _configuration["ConnectionStrings:DefaultConnection"] }).As<DbConnectionSettings>().SingleInstance();
      builder.RegisterType<DbContext>().As<IDbContext>().InstancePerLifetimeScope();
      builder.RegisterType<JobStatisticsService>().As<IJobStatisticsService>().InstancePerLifetimeScope();
    }
  }
}