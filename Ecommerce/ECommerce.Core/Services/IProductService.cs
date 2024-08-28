using ECommerce.Core.Entities;
using static ECommerce.Core.Services.IService;

namespace ECommerce.Core.Services
{
    public interface IProductService : IService<Products>
    {
        Task<Products> GetProductWithSalesByIdAsync(int productId);
    }
}
