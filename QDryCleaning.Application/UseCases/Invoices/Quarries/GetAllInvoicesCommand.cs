using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Invoices.Quarries
{
    public class GetAllInvoicesCommand : IRequest<List<InvoiceDto>>
    {
    }
}
