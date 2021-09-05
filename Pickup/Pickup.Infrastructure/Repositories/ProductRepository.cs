using Microsoft.EntityFrameworkCore;
using Pickup.Application.Interfaces.Repositories;
using Pickup.Domain.Entities.Catalog;
using System.Linq;
using System.Threading.Tasks;

namespace Pickup.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IRepositoryAsync<Product> _repository;

        public ProductRepository(IRepositoryAsync<Product> repository)
        {
            _repository = repository;
        }

        public async Task<bool> IsBrandUsed(int brandId)
        {
            return await _repository.Entities.AnyAsync(b => b.BrandId == brandId);
        }
    }
}