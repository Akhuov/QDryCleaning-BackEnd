using AutoMapper;
using QDryClean.Application.Dtos;
using QDryClean.Application.UseCases.Orders.Commands;
using QDryClean.Application.UseCases.Users.Commands;
using QDryClean.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QDryClean.Application.Mappings
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderDto>();

            CreateMap<CreateOrderCommand, OrderDto>().ReverseMap();

            CreateMap<UserDto, User>()
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
        }
    }
}
