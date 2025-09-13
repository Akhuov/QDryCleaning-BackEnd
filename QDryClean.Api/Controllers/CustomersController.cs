using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QDryClean.Application.UseCases.Customers.Commands;
using QDryClean.Domain.Enums;

namespace QDryClean.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CustomersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync(CreateCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            return Created("User created successfully.", result);
        }

        [Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCustomerAsync(DeleteCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpPut]
        public async Task<IActionResult> UpdateCustomerAsync(UpdateCustomerCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
