using ASP.Net.DTOs.PermissionDTOs;
using ASP.Net.Entities;

namespace ASP.Net.Services.PermissionServices
{
    public interface IPermissionService
    {
        Task<ServiceResults<Permission>> CreatePermission(PermissionDTO permissionDTO);
    }
}
