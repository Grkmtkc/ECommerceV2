using ECommerce.Core.Entities;

namespace ECommerce.Core.Repositories
{
    public interface IProductRepository : IGenericRepository<Products>
    {
        Task<IEnumerable<Products>> GetProductsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<IEnumerable<Products>> GetAvailableProductsAsync();
        Task<IEnumerable<Products>> GetTopSellingProductsAsync(int count);
    }
}
