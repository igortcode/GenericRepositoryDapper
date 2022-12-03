using System.Data;

namespace DapperGRP.Repository.Context.Strategy
{
    internal interface IDbStrategy
    {
        IDbConnection GetConnection(string connectionString);
    }
}
