using AutoMapper;
using QDryClean.Application.Dtos;
using QDryClean.Application.UseCases.Customers.Commands;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.Mappings
{

    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            // Entity -> DTO
            CreateMap<Customer, CustomerDto>();

            CreateMap<CustomerDto, UpdateCustomerCommand>().ReverseMap();

            CreateMap<CreateCustomerCommand, Customer>()
                .ForMember(dest => dest.Orders, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());

            // DTO -> Entity
            CreateMap<CustomerDto, Customer>()
                .ForMember(dest => dest.Orders, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
        }
    }

}
