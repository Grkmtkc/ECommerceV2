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
    public class AddressController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IAddressService _addressService;

        public AddressController(IMapper mapper, IAddressService addressService)
        {
            _mapper = mapper;
            _addressService = addressService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var addresses = await _addressService.GetAllAsync();
            var addressDtos = _mapper.Map<List<AddressDto>>(addresses);
            return CreateActionResult(CustomResponseDto<List<AddressDto>>.Success(200, addressDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var address = await _addressService.GetById(id);
            if (address == null)
            {
                return NotFound();
            }
            var addressDto = _mapper.Map<AddressDto>(address);
            return CreateActionResult(CustomResponseDto<AddressDto>.Success(200, addressDto));
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddressDto addressDto)
        {
            var address = _mapper.Map<Addresses>(addressDto);
            var newAddress = await _addressService.AddAsync(address);
            var newAddressDto = _mapper.Map<AddressDto>(newAddress);
            return CreatedAtAction(nameof(GetById), new { id = newAddressDto.Id }, CustomResponseDto<AddressDto>.Success(201, newAddressDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AddressDto addressDto)
        {
            if (id != addressDto.Id)
            {
                return BadRequest("ID mismatch");
            }

            var address = _mapper.Map<Addresses>(addressDto);
            await _addressService.UpdateAsync(address);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var address = await _addressService.GetById(id);
            if (address == null)
            {
                return NotFound();
            }

            await _addressService.RemoveAsync(address);
            return NoContent();
        }
    }
}
