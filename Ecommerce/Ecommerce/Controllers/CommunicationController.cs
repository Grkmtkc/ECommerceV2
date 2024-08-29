using AutoMapper;
using ECommerce.API.DTOs;
using ECommerce.Core.Entities;
using ECommerce.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.API.Controllers
{
    public class CommunicationController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly ICommunicationService _communicationService;

        public CommunicationController(IMapper mapper, ICommunicationService communicationService)
        {
            _mapper = mapper;
            _communicationService = communicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var communications = await _communicationService.GetAllAsync();
            var communicationDtos = _mapper.Map<List<CommunicationDto>>(communications);
            return CreateActionResult(CustomResponseDto<List<CommunicationDto>>.Success(200, communicationDtos));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var communication = await _communicationService.GetById(id);
            if (communication == null)
            {
                return NotFound();
            }
            var communicationDto = _mapper.Map<CommunicationDto>(communication);
            return CreateActionResult(CustomResponseDto<CommunicationDto>.Success(200, communicationDto));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CommunicationDto communicationDto)
        {
            var communication = _mapper.Map<Communications>(communicationDto);
            var newCommunication = await _communicationService.AddAsync(communication);
            var newCommunicationDto = _mapper.Map<CommunicationDto>(newCommunication);
            return CreatedAtAction(nameof(GetById), new { id = newCommunicationDto.Id }, CustomResponseDto<CommunicationDto>.Success(201, newCommunicationDto));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CommunicationDto communicationDto)
        {
            if (id != communicationDto.Id)
            {
                return BadRequest("ID mismatch");
            }

            var communication = _mapper.Map<Communications>(communicationDto);
            await _communicationService.UpdateAsync(communication);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var communication = await _communicationService.GetById(id);
            if (communication == null)
            {
                return NotFound();
            }

            await _communicationService.RemoveAsync(communication);
            return NoContent();
        }
    }
}
