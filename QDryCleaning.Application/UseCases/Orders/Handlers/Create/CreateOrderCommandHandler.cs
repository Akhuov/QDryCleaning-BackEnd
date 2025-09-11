using MediatR;
using QDryClean.Application.Absreactions;
using QDryClean.Application.Common.Interfaces.Services;
using QDryClean.Application.UseCases.Orders.Commands;
using QDryClean.Domain.Entities;
using QDryClean.Domain.Enums;

namespace QDryClean.Application.UseCases.Orders.Handlers.Create
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Order>
    {
        private readonly IApplicationDbContext _applicationDbContext;
        private ICurrentUserService _currentUserService;

        public CreateOrderCommandHandler(IApplicationDbContext applicationDbContext,
                                         ICurrentUserService currentUserService)
        {
            _applicationDbContext = applicationDbContext;
            _currentUserService = currentUserService;
        }


        public async Task<Order> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var order = new Order()
                {
                    ProcessStatus = Domain.Enums.ProcessStatus.Created,
                    ReceiptNumber = request.ReceiptNumber,
                    CustomerId = request.CustomerId,

                    Customer = new Customer
                    {
                        FirstName = "Test First Name",
                        LastName = "Test Last Name",
                        PhoneNumber = "+998911111111",
                        AdditionalPhoneNumber = "001",
                        Points = 0,
                        CreatedBy = _currentUserService.UserId,
                        CreatedAt = DateTime.Now
                    },


                    Invoice = new Invoice
                    {
                        PaymentStatus = PaymentStatus.NotPaid,
                        Discount = 0,
                        TotalCost = 100,
                        Notes = "Created Invoice"
                    },


                    ExpectedCompletionDate = DateOnly.FromDateTime(DateTime.Now.AddDays(3)),
                    CreatedAt = DateTime.Now,
                    CreatedBy = _currentUserService.UserId,
                    Notes = "Some Note"
                }; 

                await _applicationDbContext.Orders.AddAsync(order);
                await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return order;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
