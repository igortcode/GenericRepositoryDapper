using DapperGRP.Domain.Entities;
using DapperGRP.Domain.Interfaces.Repository;
using DapperGRP.Domain.Settings;
using Microsoft.Extensions.Options;

namespace DapperGRP.Repository.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(IOptions<DatabaseSettings> settings) : base(settings){}
    }
}
