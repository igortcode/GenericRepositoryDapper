using System.Data;
using System.Data.SqlClient;

namespace DapperGRP.Repository.Context.Strategy
{
    public class SqlServerStrategy : IDbStrategy
    {
        public IDbConnection GetConnection(string connectionString)
        {
           return new SqlConnection(connectionString);
        }
    }
}
