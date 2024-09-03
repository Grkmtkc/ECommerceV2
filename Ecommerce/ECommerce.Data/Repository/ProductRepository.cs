using ECommerce.Core.Entities;
using ECommerce.Core.Repositories;
using ECommerce.Data.Context;
using ECommerce.Data.Repository;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce.Data.Repository
{
    public class ProductRepository : GenericRepository<Products>, IProductRepository
    {
        public ProductRepository(ECommerceDbContext context) : base(context)
        {
        }

        public async Task<Products> GetWithSalesByIdAsync(int productId)
        {
            return await _dbSet
                .Where(p => p.Id == productId)
                .Include(p => p.Sales)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Products>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await _dbSet
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .ToListAsync();
        }

        public async Task<IEnumerable<Products>> GetAvailableProductsAsync()
        {
            return await _dbSet
                .Where(p => p.StockQuantity > 0)
                .ToListAsync();
        }

        public async Task<IEnumerable<Products>> GetTopSellingProductsAsync(int count)
        {
            return await _dbSet
                .OrderByDescending(p => p.Sales.Sum(s => s.Quantity))
                .Take(count)
                .ToListAsync();
        }
    }
}
