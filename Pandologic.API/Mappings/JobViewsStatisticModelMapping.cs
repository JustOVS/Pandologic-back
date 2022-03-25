using AutoMapper;
using Pandologic.API.Models;
using Pandologic.Logic.JobStatistics;

namespace Pandologic.API.Mappings
{
  public class JobViewsStatisticModelMapping : Profile
  {
    public JobViewsStatisticModelMapping()
    {
      CreateMap<JobViewsStatistic, JobViewsStatisticModel>()
        .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
        .ForMember(dest => dest.PredictionsQuantity, opt => opt.MapFrom(src => src.PredictionsQuantity))
        .ForMember(dest => dest.JobsQuantity, opt => opt.MapFrom(src => src.JobsQuantity))
        .ForMember(dest => dest.ViewsQuantity, opt => opt.MapFrom(src => src.ViewsQuantity));
    }
  }
}
