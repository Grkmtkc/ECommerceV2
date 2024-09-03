using AutoMapper;
using ECommerce.API.DTOs;
using ECommerce.Core.Entities;
using ECommerce.Core.Services;
using Microsoft.AspNetCore.Mvc;




namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;

        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        [HttpGet]

        public async Task<IActionResult> All()
          {
           var products = await _productService.GetAllAsync();
           var productsDto= _mapper.Map<List<ProductDto>>(products);
           return CreateActionResult(CustomResponseDto<List<ProductDto>>.Success(200, productsDto));

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetById(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(200, productDto));
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto productDto)
        {
            var product = _mapper.Map<Products>(productDto);
            var newProduct = await _productService.AddAsync(product);
            var newProductDto = _mapper.Map<ProductDto>(newProduct);
            return CreateActionResult(CustomResponseDto<ProductDto>.Success(201, newProductDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            var product = _mapper.Map<Products>(productDto);
            await _productService.UpdateAsync(product);
            return NoContent();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productService.GetById(id);
            if (product == null)
            {
                return NotFound();
            }
            await _productService.RemoveAsync(product);
            return NoContent();
        }
    }
}
