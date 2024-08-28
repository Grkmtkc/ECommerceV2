using ECommerce.Core.Entities;

namespace ECommerce.Core.Repositories
{
    public interface ICustomerRepository : IGenericRepository<Customers>
    {
        Task<IEnumerable<Customers>> GetCustomersByAgeAsync(int age);
        Task<IEnumerable<Customers>> GetActiveCustomersAsync();
    }
}
