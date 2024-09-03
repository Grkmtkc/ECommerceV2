using ECommerce.Core.Entities;

namespace ECommerce.Core.Repositories
{
    public interface IProductRepository : IGenericRepository<Products>
    {
        Task<Products> GetWithSalesByIdAsync(int productId);
    }
}
