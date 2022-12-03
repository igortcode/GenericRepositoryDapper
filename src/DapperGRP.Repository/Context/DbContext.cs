using DapperGRP.Repository.Context.Strategy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperGRP.Repository.Context
{
    public class DbContext
    {
        private IDbStrategy _dbStrategy;

        public DbContext SetStrategy(string providerType)
        {
            _dbStrategy = providerType switch
            {
                "SqlServer" => _dbStrategy = new SqlServerStrategy(),
                _ => null
            };

            return this;
        }

        public IDbConnection GetDbContext(string connectionString)
            => _dbStrategy.GetConnection(connectionString);
    }
}
