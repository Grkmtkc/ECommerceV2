using ECommerce.Core.Entities;
using static ECommerce.Core.Services.IService;

namespace ECommerce.Core.Services
{
    public interface ICustomerService : IService<Customers>
    {
        Task<Customers> GetByIdAsync(int id);
        Task<Customers> GetCustomerWithDetailsByIdAsync(int customerId);
    }
}
