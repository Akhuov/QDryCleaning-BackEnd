using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QDryClean.Application.UseCases.Orders.Commands;
using QDryClean.Application.UseCases.Orders.Quarries;
using QDryClean.Domain.Enums;

namespace QDryClean.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public OrdersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        
        
        [Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync(CreateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Created("Order created successfully.", result);
        }
        
        
        [Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderAsync(DeleteOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        
        
        [Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpPut]
        public async Task<IActionResult> UpdateOrderAsync(UpdateOrderCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        
        
        [HttpGet]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var command = new GetAllOrdersCommand();
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpGet("OrderId")]
        public async Task<IActionResult> GetByIdItemTypeAsync(int id)
        {
            var command = new GetByIdOrderCommand() { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
