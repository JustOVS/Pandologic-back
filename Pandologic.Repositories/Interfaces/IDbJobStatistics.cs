using Insight.Database;
using Pandologic.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pandologic.Repositories.Interfaces
{
  [Sql(Schema = "dbo")]
  public interface IDbJobStatistics
  {
    Task<List<DbJobViewsStatistic>> GetJobViewsStatisticsAsync(List<DateTime> dates);
  }
}