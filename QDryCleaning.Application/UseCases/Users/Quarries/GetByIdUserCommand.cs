using MediatR;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.UseCases.Users.Quarries
{
    public class GetByIdUserCommand : IRequest<User>
    {
        public int Id { get; set; }
    }
}
