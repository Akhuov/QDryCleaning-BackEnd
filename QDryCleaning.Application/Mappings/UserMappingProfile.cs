using AutoMapper;
using QDryClean.Application.Dtos;
using QDryClean.Application.UseCases.Users.Commands;
using QDryClean.Domain.Entities;

namespace QDryClean.Application.Mappings
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDto>();

            CreateMap<CreateUserCommand,UserDto>().ReverseMap();

            CreateMap<UserDto, User>()
                .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedBy, opt => opt.Ignore())
                .ForMember(dest => dest.UpdatedAt, opt => opt.Ignore());
        }
    }
}
