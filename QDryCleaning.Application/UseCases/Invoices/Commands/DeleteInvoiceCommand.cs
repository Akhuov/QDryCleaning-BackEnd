using MediatR;

namespace QDryClean.Application.UseCases.Invoices.Commands
{
    public class DeleteInvoiceCommand : IRequest<string>
    {
        public int Id { get; set; }
    }
}
