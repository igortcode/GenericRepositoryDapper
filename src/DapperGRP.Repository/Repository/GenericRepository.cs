using Dapper.Contrib.Extensions;
using DapperGRP.Domain.Entities;
using DapperGRP.Domain.Interfaces.Repository;
using DapperGRP.Domain.Settings;
using DapperGRP.Repository.Context;
using Microsoft.Extensions.Options;
using System.Data;
using static Dapper.SqlMapper;

namespace DapperGRP.Repository.Repository
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : Entity
    {
        protected IDbConnection DbConnection { get; private set; }
        private readonly DatabaseSettings _dbSettings;

        public GenericRepository(IOptions<DatabaseSettings> settings)
        {
            _dbSettings = settings.Value;
            DbConnection = new DbContext()
                .SetStrategy(_dbSettings.ProviderName)
                .GetDbContext(_dbSettings.ConnectionString);
        }

        public async Task<bool> CreateAsync(TEntity entity)
        {
            DbConnection.Open();
            try
            {
                var result = await DbConnection.InsertAsync(entity);
                return result == 0;
            }
            finally
            {
                DbConnection.Close();
            }

        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            DbConnection.Open();
            try
            {
                var entity = await DbConnection.GetAsync<TEntity>(id);

                if (entity == null)
                    return false;

                return await DbConnection
                    .DeleteAsync(entity);
            }
            finally
            {
                DbConnection.Close();
            }
        }

        public async Task<IQueryable<TEntity>> FindAllAsync()
        {
            DbConnection.Open();
            try
            {
                var results = await DbConnection
                    .GetAllAsync<TEntity>();

                return results
                    .AsQueryable();
            }
            finally
            {
                DbConnection.Close();
            }
        }

        public async Task<TEntity> FindByIdAsync(Guid id)
        {
            DbConnection.Open();

            try
            {
                return await DbConnection
                    .GetAsync<TEntity>(id);
            }
            finally { DbConnection.Close(); }
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            DbConnection.Open();

            try
            {
                return await DbConnection
                    .UpdateAsync(entity);
            }
            finally { DbConnection.Close(); }
        }
    }
}
