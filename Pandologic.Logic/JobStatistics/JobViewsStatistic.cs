using System;

namespace Pandologic.Logic.JobStatistics
{
  public class JobViewsStatistic
  {
    public DateTime Date { get; set; }
    public long PredictionsQuantity { get; set; }
    public long ViewsQuantity { get; set; }
    public long JobsQuantity { get; set; }
  }
}