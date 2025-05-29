using ASP.Net.DTOs.AuthDTOs;
using ASP.Net.Entities;
using AutoMapper;

namespace ASP.Net.Configuration
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.ImageUrl, opt => opt.Ignore())
            .ForMember(dest => dest.IsActive, opt => opt.Ignore())
            .ForMember(dest => dest.Created_At, opt => opt.Ignore())
            .ForMember(dest => dest.Updated_At, opt => opt.Ignore());
        }
    }
}
