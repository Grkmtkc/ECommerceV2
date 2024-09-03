using AutoMapper;
using ECommerce.API.DTOs;
using ECommerce.Core.Entities;
using ECommerce.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICustomerService _customerService;

        public CustomerController(IMapper mapper, ICustomerService customerService)
        {
            _mapper = mapper;
            _customerService = customerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllAsync();
            var customerDtos = _mapper.Map<List<CustomerDto>>(customers);
            return CreateActionResult(CustomResponseDto<List<CustomerDto>>.Success(200, customerDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerService.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }
            var customerDto = _mapper.Map<CustomerDto>(customer);
            return CreateActionResult(CustomResponseDto<CustomerDto>.Success(200, customerDto));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var customer = _mapper.Map<Customers>(customerDto);
            var newCustomer = await _customerService.AddAsync(customer);
            var newCustomerDto = _mapper.Map<CustomerDto>(newCustomer);
            return CreatedAtAction(nameof(GetById), new { id = newCustomerDto.Id }, CustomResponseDto<CustomerDto>.Success(201, newCustomerDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerDto.Id)
            {
                return BadRequest("ID mismatch");
            }

            var customer = _mapper.Map<Customers>(customerDto);
            await _customerService.UpdateAsync(customer);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var customer = await _customerService.GetById(id);
            if (customer == null)
            {
                return NotFound();
            }

            await _customerService.RemoveAsync(customer);
            return NoContent();
        }
    }
}

