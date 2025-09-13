using AutoMapper;
using QDryClean.Application.Dtos;
using QDryClean.Application.UseCases.Charges.Commands;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.Mappings
{
    public class ChargeMappingProfile : Profile
    {
        public ChargeMappingProfile()
        {
            CreateMap<Charge, ChargeDto>();
            CreateMap<ChargeDto, CreateChargeCommand>().ReverseMap();
            CreateMap<ChargeDto, Charge>()
                .ForMember(dest => dest.ItemType, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
        }
    }
}
