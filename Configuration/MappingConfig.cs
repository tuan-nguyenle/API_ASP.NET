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

            CreateMap<Role, RoleDTO>();
            CreateMap<RoleDTO, Role>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                .ForMember(dest => dest.Created_At, opt => opt.Ignore())
                .ForMember(dest => dest.Updated_At, opt => opt.Ignore());

            CreateMap<Permission, PermissionDTO>();
            CreateMap<PermissionDTO, Permission>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Created_At, opt => opt.Ignore())
                .ForMember(dest => dest.Updated_At, opt => opt.Ignore());

            CreateMap<Resource, ResourceDTO>();
            CreateMap<ResourceDTO, Resource>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Created_At, opt => opt.Ignore())
                .ForMember(dest => dest.Updated_At, opt => opt.Ignore());

            CreateMap<UserRole, UserRoleDTO>();
            CreateMap<UserRoleDTO, UserRole>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                .ForMember(dest => dest.Assigned_At, opt => opt.Ignore())
                .ForMember(dest => dest.Revoked_At, opt => opt.Ignore());

            CreateMap<RolePermission, RolePermissionDTO>();
            CreateMap<RolePermissionDTO, RolePermission>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                .ForMember(dest => dest.Assigned_At, opt => opt.Ignore())
                .ForMember(dest => dest.Revoked_At, opt => opt.Ignore());
        }
    }
}
