using AutoMapper;
using Pandologic.Repositories.Entities;

namespace Pandologic.Logic.JobStatistics
{
  public class JobViewsStatisticMapping : Profile
  {
    public JobViewsStatisticMapping()
    {
      CreateMap<DbJobViewsStatistic, JobViewsStatistic>()
        .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
        .ForMember(dest => dest.PredictionsQuantity, opt => opt.MapFrom(src => src.PredictionsQuantity))
        .ForMember(dest => dest.JobsQuantity, opt => opt.MapFrom(src => src.JobsQuantity))
        .ForMember(dest => dest.ViewsQuantity, opt => opt.MapFrom(src => src.ViewsQuantity));
    }
  }
}