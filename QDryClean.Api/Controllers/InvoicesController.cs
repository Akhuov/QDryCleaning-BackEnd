using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QDryClean.Application.UseCases.Invoices.Commands;
using QDryClean.Application.UseCases.Invoices.Quarries;
using QDryClean.Domain.Enums;

namespace QDryClean.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public InvoicesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpPost]
        public async Task<IActionResult> CreateInvoiceAsync(CreateInvoiceCommand command)
        {
            var result = await _mediator.Send(command);
            return Created("Invoice created successfully.", result);
        }
        [Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpDelete]
        public async Task<IActionResult> DeleteInvoiceAsync(DeleteInvoiceCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [Authorize(Roles = $"{nameof(UserRole.Receptionist)},{nameof(UserRole.Admin)}")]
        [HttpPut]
        public async Task<IActionResult> UpdateInvoiceAsync(UpdateInvoiceCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllInvoicesAsync()
        {
            var command = new GetAllInvoicesCommand();
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("InvoiceId")]
        public async Task<IActionResult> GetByIdInvoiceAsync(int id)
        {
            var command = new GetByIdInvoiceCommand() { Id = id };
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
