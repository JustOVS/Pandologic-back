using Insight.Database;
using Pandologic.Repositories.Interfaces;
using System;
using System.Data;
using System.Data.Common;

namespace Pandologic.Repositories
{
  public class DbContext : IDbContext
  {
    public IDbConnection Connection { get; set; }

    public IDbJobStatistics JobStatistics => CreateRepository<IDbJobStatistics>();

    public DbContext(DbConnectionSettings connectionStringSettings)
    {
      SqlInsightDbProvider.RegisterProvider();

      var providerFactory = DbProviderFactories.GetFactory(DbConnectionSettings.ProviderName);
      Connection = providerFactory.CreateConnection() ?? throw new Exception("Connection object is null");
      Connection.ConnectionString = connectionStringSettings.ConnectionString;
    }

    public TRepository CreateRepository<TRepository>() where TRepository : class
    {
      return Connection.As<TRepository>();
    }
  }
}