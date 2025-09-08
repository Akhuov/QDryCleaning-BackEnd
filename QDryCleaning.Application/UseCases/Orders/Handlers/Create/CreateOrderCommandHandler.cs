using MediatR;
using QDryClean.Application.Absreactions;
using QDryClean.Application.UseCases.Orders.Commands;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Orders.Handlers.Create
{
    public class CreateOrderCommandHandler : AsyncRequestHandler<CreateOrderCommand>
    {
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateOrderCommandHandler(IApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;

        }

        protected override async Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {

            try
            {
                var order = new Order()
                {
                    ProcessStatus = Domain.Enums.ProcessStatus.Created,
                    ReceiptNumber = request.ReceiptNumber,
                    CustomerId = request.CustomerId,
                    ExpectedCompletionDate = DateOnly.FromDateTime(DateTime.Now.AddDays(3))
                };
                
                await _applicationDbContext.Orders.AddAsync(order);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var r = ex.Message;
            }
        }
    }
}
