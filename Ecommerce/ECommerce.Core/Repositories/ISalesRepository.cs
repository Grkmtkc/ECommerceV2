using ECommerce.Core.Entities;

namespace ECommerce.Core.Repositories
{
    public interface ISalesRepository : IGenericRepository<Sales>
    {
        Task<IEnumerable<Sales>> GetSalesByCustomerIdAsync(int customerId);
        Task<IEnumerable<Sales>> GetSalesByProductIdAsync(int productId);
        Task<IEnumerable<Sales>> GetTopSalesAsync(int count);
    }
}
