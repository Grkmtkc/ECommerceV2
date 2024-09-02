using ECommerce.Core.Entities;
using ECommerce.Core.Repositories;
using ECommerce.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace ECommerce.Data.Repository
{
    public class SaleRepository : GenericRepository<Sales>, ISalesRepository
    {
        public SaleRepository(ECommerceDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Sales>> GetSalesByCustomerIdAsync(int customerId)
        {
            return await _dbSet
                .Where(s => s.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Sales>> GetSalesByProductIdAsync(int productId)
        {
            return await _dbSet
                .Where(s => s.ProductId == productId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Sales>> GetTopSalesAsync(int count)
        {
            return await _dbSet
                .OrderByDescending(s => s.Quantity)
                .Take(count)
                .ToListAsync();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ISalesRepository, SaleRepository>();

        }
    }
}
