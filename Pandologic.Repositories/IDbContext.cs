using Pandologic.Repositories.Interfaces;
using System.Data;

namespace Pandologic.Repositories
{
  public interface IDbContext
  {
    IDbConnection Connection { get; set; }
    IDbJobStatistics JobStatistics { get; }
  }
}