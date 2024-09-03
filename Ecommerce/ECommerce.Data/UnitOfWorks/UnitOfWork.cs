using Ecommerce.Data.Repository;
using ECommerce.Core.Repositories;
using ECommerce.Core.UnitOfWorks;
using ECommerce.Data.Context;
using ECommerce.Data.Repository;

namespace ECommerce.Data.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWorks
    {
        private readonly ECommerceDbContext _context;

        private IProductRepository _productRepository;
        private IAddressRepository _addressRepository;
        private ICommunicationRepository _communicationRepository;
        private ICustomerRepository _customerRepository;
        private ISalesRepository _salesRepository;

        public UnitOfWork(ECommerceDbContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository
            => _productRepository ??= new ProductRepository(_context);
        public IAddressRepository AddressRepository
            => _addressRepository ??= new AddressRepository(_context);
        public ICommunicationRepository CommunicationRepository
            => _communicationRepository ??= new CommunicationRepository(_context);
        public ICustomerRepository CustomerRepository
            => _customerRepository ??= new CustomerRepository(_context);
        public ISalesRepository SalesRepository
            => _salesRepository ??= new SaleRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task CompleteAsync()
        {
            await CommitAsync();
        }
    }
}
