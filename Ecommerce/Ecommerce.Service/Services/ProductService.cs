using ECommerce.Core.Entities;
using ECommerce.Core.Repositories;
using ECommerce.Core.Services;
using ECommerce.Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Service.Services
{
    public class ProductService : Service<Products>, IProductService
    {
        private readonly IUnitOfWorks _unitOfWork;
        private readonly IGenericRepository<Products> _productRepository;

        public ProductService(IUnitOfWorks unitOfWork, IGenericRepository<Products> productRepository)
            : base(productRepository, unitOfWork) // Calls the base class constructor
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
        }

        public async Task<Products> GetProductWithSalesByIdAsync(int productId)
        {
            return await _productRepository
                .Where(p => p.Id == productId)
                .Include(p => p.Sales)
                .FirstOrDefaultAsync();
        }
    }
}
