using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Invoices.Quarries
{
    public class GetByIdInvoiceCommand : IRequest<InvoiceDTO>
    {
        public Guid Id { get; set; }
    }
}
