using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QDryClean.Application.UseCases.Items.Commands;
using QDryClean.Application.UseCases.Items.Querries;
using QDryClean.Domain.Enums;

namespace QDryClean.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ItemsController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpPost]
        public async Task<IActionResult> CreateItemAsync(CreateItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Created("ItemType created successfully.", result);
        }

        [Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteItemAsync(DeleteItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpPut]
        public async Task<IActionResult> UpdateItemAsync(UpdateItemCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItemTypesAsync()
        {
            var command = new GetAllItemsQuerry();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("ItemTypeId")]
        public async Task<IActionResult> GetByIdItemTypeAsync(int id)
        {
            var command = new GetByIdItemQuerry() { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
