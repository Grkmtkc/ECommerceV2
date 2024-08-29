using AutoMapper;
using ECommerce.API.DTOs;
using ECommerce.Core.Entities;
using ECommerce.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ISalesService _saleService;

        public SaleController(IMapper mapper, ISalesService saleService)
        {
            _mapper = mapper;
            _saleService = saleService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var sales = await _saleService.GetAllAsync();
            var salesDto = _mapper.Map<List<SaleDto>>(sales);
            return CreateActionResult(CustomResponseDto<List<SaleDto>>.Success(200, salesDto));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sale = await _saleService.GetById(id);
            if (sale == null)
            {
                return NotFound();
            }
            var saleDto = _mapper.Map<SaleDto>(sale);
            return CreateActionResult(CustomResponseDto<SaleDto>.Success(200, saleDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(SaleDto saleDto)
        {
            var sale = _mapper.Map<Sales>(saleDto);
            var newSale = await _saleService.AddAsync(sale);
            var newSaleDto = _mapper.Map<SaleDto>(newSale);
            return Created(string.Empty, CustomResponseDto<SaleDto>.Success(201, newSaleDto));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var sale = await _saleService.GetById(id);
            if (sale == null)
            {
                return NotFound();
            }
            await _saleService.RemoveAsync(sale);
            return NoContent();
        }
    }
}
