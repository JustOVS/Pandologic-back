using System;

namespace Pandologic.Repositories.Entities
{
  public class DbJobViewsStatistic
  {
    public DateTime Date { get; set; }
    public long PredictionsQuantity { get; set; }
    public long ViewsQuantity { get; set; }
    public long JobsQuantity { get; set; }
  }
}