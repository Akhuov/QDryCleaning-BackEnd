using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Invoices.Commands
{
    public class UpdateInvoiceCommand : InvoiceDto, IRequest<InvoiceDto>
    {
    }
}
