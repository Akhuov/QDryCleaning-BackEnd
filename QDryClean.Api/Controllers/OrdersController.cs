using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using QDryClean.Application.UseCases.Orders.Commands;
using QDryClean.Domain.Entities;

namespace QDryClean.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private readonly IMediator _mediator;
        private readonly IMemoryCache _memoryCache;

        public OrdersController(IMediator mediator, IMemoryCache memoryCache)
        {
            _mediator = mediator;
            _memoryCache = memoryCache;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderAsync(Order order)
        {
            try
            {
                var command = new CreateOrderCommand
                {
                    ReceiptNumber = order.ReceiptNumber,
                    CustomerId = order.CustomerId

                };
                await _mediator.Send(command);
                return Ok(order);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }
    }
}
