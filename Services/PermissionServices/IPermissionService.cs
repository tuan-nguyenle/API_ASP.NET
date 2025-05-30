using ASP.Net.DTOs.AuthDTOs;
using ASP.Net.Entities;

namespace ASP.Net.Services.PermissionServices
{
    public interface IPermissionService
    {
        Task<ServiceResults<Permission>> CreatePermission(PermissionDTO permissionDTO);
    }
}
