namespace Pandologic.Repositories
{
  public class DbConnectionSettings
  {
    public static string ProviderName => "System.Data.SqlClient";
    public string ConnectionString { get; set; }
    public int CommandTimeout { get; set; }
  }
}