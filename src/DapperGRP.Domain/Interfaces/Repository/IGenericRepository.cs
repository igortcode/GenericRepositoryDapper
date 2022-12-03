using DapperGRP.Domain.Entities;

namespace DapperGRP.Domain.Interfaces.Repository
{
    public interface IGenericRepository<TEntity>
    {
        Task<IQueryable<TEntity>> FindAllAsync();
        Task<TEntity> FindByIdAsync(Guid id);
        Task<bool> CreateAsync(TEntity entity);
        Task<bool> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(Guid id);
    }
}
