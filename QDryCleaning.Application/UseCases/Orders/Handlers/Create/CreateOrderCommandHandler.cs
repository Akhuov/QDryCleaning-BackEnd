using MediatR;
using QDryClean.Application.Absreactions;
using QDryClean.Application.UseCases.Orders.Commands;

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
                var order = new Domain.Entities.Order()
                {
                    Name = request.Name,
                    Description = request.Description,
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
