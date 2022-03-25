using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pandologic.API.Models;
using Pandologic.Logic.JobStatistics;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pandologic.API.Controllers
{
  [Route("job-statistics")]
  [ApiController]
  public class JobStatisticsController : ControllerBase
  {
    private readonly IJobStatisticsService _jobStatisticsService;
    private readonly IMapper _mapper;

    public JobStatisticsController(IJobStatisticsService jobStatisticsService, IMapper mapper)
    {
      _jobStatisticsService = jobStatisticsService;
      _mapper = mapper;
    }

    [HttpGet]
    [Route("")]
    [ProducesResponseType(typeof(IList<JobViewsStatisticModel>), StatusCodes.Status200OK)]
    public async Task<ActionResult<IList<JobViewsStatisticModel>>> GetJobViewsStatisticsAsync(DateTime from, DateTime to)
    {
      var result = await _jobStatisticsService.GetJobViewsStatisticsAsync(from, to);

      return Ok(_mapper.Map<List<JobViewsStatisticModel>>(result));
    }
  }
}
