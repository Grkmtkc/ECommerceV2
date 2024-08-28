using ECommerce.Core.Entities;
using static ECommerce.Core.Services.IService;

namespace ECommerce.Core.Services
{
    public interface ICustomerService : IService<Customers>
    {
        Task<Customers> GetCustomerWithDetailsByIdAsync(int customerId);
    }
}
