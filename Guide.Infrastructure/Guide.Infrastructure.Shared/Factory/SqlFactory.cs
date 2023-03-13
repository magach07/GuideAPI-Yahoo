using System.Data;
using Microsoft.Data.SqlClient;

namespace Guide.Infrastructure.Shared.Factory
{
    public class SqlFactory
    {
        public IDbConnection GetSqlConnection()
        {
            return new SqlConnection("Server=desktop-n3ub7sm;DataBase=YAHOO_FINANCE;User=sa;Password=windowslinuxj;Trusted_Connection=false;TrustServerCertificate=True;");
        }
    }
}