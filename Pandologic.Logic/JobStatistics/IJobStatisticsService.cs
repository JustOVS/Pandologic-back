using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pandologic.Logic.JobStatistics
{
  public interface IJobStatisticsService
  {
    Task<IList<JobViewsStatistic>> GetJobViewsStatisticsAsync(DateTime from, DateTime to);
  }
}