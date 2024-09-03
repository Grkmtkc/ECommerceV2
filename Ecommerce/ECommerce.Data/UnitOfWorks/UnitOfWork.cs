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

        private ProductRepository _productRepository;
        private AddressRepository _addressRepository;
        private CommunicationRepository _communicationRepository;
        private CustomerRepository _customerRepository;
        private SaleRepository _saleRepository;

        public UnitOfWork(ECommerceDbContext context)
        {
            _context = context;
        }

        public IProductRepository product => _productRepository = _productRepository ?? new ProductRepository(_context);
        public IAddressRepository address => _addressRepository = _addressRepository ?? new AddressRepository(_context);
        public ICommunicationRepository communication => _communicationRepository = _communicationRepository ?? new CommunicationRepository(_context);
        public ICustomerRepository customer => _customerRepository = _customerRepository ?? new CustomerRepository(_context);
        public ISalesRepository sales => _saleRepository = _saleRepository ?? new SaleRepository(_context);

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
