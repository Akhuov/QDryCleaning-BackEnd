using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDryClean.Application.UseCases.Orders.Commands
{
    public class DeleteOrderCommand : IRequest<string>
    {
        public int Id { get; set; } 
    }
}
