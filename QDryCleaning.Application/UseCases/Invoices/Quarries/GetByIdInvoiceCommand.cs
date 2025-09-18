using MediatR;
using QDryClean.Application.Dtos;

namespace QDryClean.Application.UseCases.Invoices.Quarries
{
    public class GetByIdInvoiceCommand : IRequest<InvoiceDto>
    {
        public int Id { get; set; }
    }
}
