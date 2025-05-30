using ASP.Net.DTOs.AuthDTOs;
using ASP.Net.Entities;

namespace ASP.Net.Services.RoleServices
{
    public interface IRoleService
    {
        Task<ServiceResults<Role>> CreateRole(RoleDTO roleDTO);
        //Task<ServiceResults<List<Role>>> GetAllRoles();
        //Task<ServiceResults<Role>> GetRoleById(int id);
        //Task<ServiceResults<Role>> UpdateRole(int id, RoleDTO roleDTO);
        //Task<ServiceResults<bool>> DeleteRole(int id);
    }

}
