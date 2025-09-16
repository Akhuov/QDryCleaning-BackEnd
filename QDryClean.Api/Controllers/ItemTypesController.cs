using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QDryClean.Application.UseCases.ItemTypes.Commands;
using QDryClean.Application.UseCases.ItemTypes.Quarries;
using QDryClean.Domain.Enums;

namespace QDryClean.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemTypesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ItemTypesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpPost]
        public async Task<IActionResult> CreateItemTypeAsync(CreateItemTypeCommand command)
        {
            var result = await _mediator.Send(command);
            return Created("ItemType created successfully.", result);
        }
        [Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteItemTypeAsync(DeleteItemTypeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpPut]
        public async Task<IActionResult> UpdateItemTypeAsync(UpdateItemTypeCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllItemTypesAsync()
        {
            var command = new GetAllItemTypesCommand();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("{userId:int}")]
        public async Task<IActionResult> GetByIdItemTypeAsync(int id)
        {
            var command = new GetByIdItemTypeCommand() { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
