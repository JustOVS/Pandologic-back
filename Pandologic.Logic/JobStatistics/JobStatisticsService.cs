using AutoMapper;
using Pandologic.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pandologic.Logic.JobStatistics
{
  public class JobStatisticsService : IJobStatisticsService
  {
    private readonly IDbContext _dbContext;
    private readonly IMapper _mapper;

    public JobStatisticsService(IDbContext dbContext, IMapper mapper)
    {
      _dbContext = dbContext;
      _mapper = mapper;
    }

    public async Task<IList<JobViewsStatistic>> GetJobViewsStatisticsAsync(DateTime from, DateTime to)
    {
      var dates = new List<DateTime>();

      for (var dt = from; dt <= to; dt = dt.AddDays(1))
      {
        dates.Add(dt);
      }
      
      var dbEntities = await _dbContext.JobStatistics.GetJobViewsStatisticsAsync(dates);
      
      return _mapper.Map<List<JobViewsStatistic>>(dbEntities);
    }
  }
}