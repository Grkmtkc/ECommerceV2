using ECommerce.Core.Entities;
using ECommerce.Core.Repositories;
using ECommerce.Data.Context;
using Microsoft.EntityFrameworkCore;


namespace ECommerce.Data.Repository
{
    public class ProductRepository : GenericRepository<Products>, IProductRepository
    {
        public ProductRepository(ECommerceDbContext context) : base(context)
        {
        }

        // Fiyat aralığına göre ürünleri getirme
        public async Task<IEnumerable<Products>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await _dbSet
                .Where(p => p.Price >= minPrice && p.Price <= maxPrice)
                .ToListAsync();
        }

        // Stokta olan ürünleri getirme
        public async Task<IEnumerable<Products>> GetAvailableProductsAsync()
        {
            return await _dbSet
                .Where(p => p.StockQuantity > 0)
                .ToListAsync();
        }

        // En çok satan ürünleri getirme
        public async Task<IEnumerable<Products>> GetTopSellingProductsAsync(int count)
        {
            return await _dbSet
                .OrderByDescending(p => p.Sales.Sum(s => s.Quantity))
                .Take(count)
                .ToListAsync();
        }
    }
}
