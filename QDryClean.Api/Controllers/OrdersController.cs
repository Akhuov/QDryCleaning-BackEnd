using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using QDryClean.Application.Dtos;
using QDryClean.Application.UseCases.Orders.Commands;

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
        public async Task<IActionResult> CreateOrderAsync(OrderDto order)
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
