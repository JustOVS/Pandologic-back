using System;

namespace Pandologic.API.Models
{
  public class JobViewsStatisticModel
  {
    public DateTime Date { get; set; }
    public long PredictionsQuantity { get; set; }
    public long ViewsQuantity { get; set; }
    public long JobsQuantity { get; set; }
  }
}