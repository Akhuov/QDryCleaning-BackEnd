using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Invoices.Commands
{
    public class CreateInvoiceCommand : InvoiceDTO , IRequest<InvoiceDTO>
    {
    }
}
