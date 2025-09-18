using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.Dtos;
using QDryClean.Application.Exceptions;
using QDryClean.Application.UseCases.Invoices.Commands;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Invoices.Handlers
{
    public class CreateInvoiceCommandHandler : CommandHandlerBase, IRequestHandler<CreateInvoiceCommand, InvoiceDto>
    {
        public CreateInvoiceCommandHandler(
            IApplicationDbContext applicationDbContext,
            ICurrentUserService currentUserService,
            IMapper mapper) : base(applicationDbContext, currentUserService, mapper) { }
        public async Task<InvoiceDto> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var invoice = await _applicationDbContext.OrderInvoices.FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);
                if (invoice is null)
                {
                    invoice = _mapper.Map<Invoice>(request);
                    await _applicationDbContext.OrderInvoices.AddAsync(invoice, cancellationToken);
                    await _applicationDbContext.SaveChangesAsync(cancellationToken);
                    return _mapper.Map<InvoiceDto>(invoice);
                }
                else
                {
                    throw new BadRequestExeption("Invoice with this id already exists");
                }
            }
            catch (BadRequestExeption)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new InternalServerExeption(ex.Message);
            }
        }
    }
}
