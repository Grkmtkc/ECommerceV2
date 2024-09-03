using ECommerce.Core.Entities;
using ECommerce.Core.Repositories;
using ECommerce.Core.Services;
using ECommerce.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ecommerce.Service.Services
{
    public class CustomerService : Service<Customers>, ICustomerService
    {
        private readonly IGenericRepository<Customers> _customerRepository;
        private readonly IUnitOfWorks _unitOfWork;

        public CustomerService(IGenericRepository<Customers> customerRepository, IUnitOfWorks unitOfWork)
            : base(customerRepository, unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Customers> GetByIdAsync(int id)
        {
            return await _customerRepository.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Customers> GetCustomerWithDetailsByIdAsync(int customerId)
        {
            return await _customerRepository
                .Where(c => c.Id == customerId)
                .Include(c => c.Addresses)
                .Include(c => c.Communications)
                .Include(c => c.Sales)
                .FirstOrDefaultAsync();
        }

        public async Task<Customers> AddAsync(Customers customer)
        {
            await _customerRepository.AddAsync(customer);
            await _unitOfWork.CompleteAsync();
            return customer;
        }
    }
}
