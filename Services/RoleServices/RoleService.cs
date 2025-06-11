using ASP.Net.Data;
using ASP.Net.DTOs.RoleDTOs;
using ASP.Net.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net.Services.RoleServices
{
    public class RoleService(AuthDbContext context, IMapper mapper) : IRoleService
    {
        private readonly AuthDbContext _context = context;
        private readonly IMapper _mapper = mapper;
        public async Task<ServiceResults<Role>> CreateRole(RoleDTO roleDTO)
        {
            try
            {
                var existingRole = await _context.Roles
                    .FirstOrDefaultAsync(r => r.Name == roleDTO.Name);

                if (existingRole != null)
                {
                    throw new Exception("Role with this name already exists");
                }

                var role = _mapper.Map<Role>(roleDTO);

                _context.Roles.Add(role);

                await _context.SaveChangesAsync();

                return ServiceResults<Role>.Success(role);
            }
            catch (Exception ex)
            {
                return ServiceResults<Role>.Failure(ex.Message);
            }
        }

        public async Task<ServiceResults<UserRole>> AssignRoleToUser(UserRoleDTO userRoleDTO)
        {
            try
            {
                var user = await _context.Users.FindAsync(userRoleDTO.UserId) ?? throw new Exception("User not found");

                var role = await _context.Roles.FindAsync(userRoleDTO.RoleId) ?? throw new Exception("Role not found");

                var existingUserRole = await _context.UserRoles
                    .FirstOrDefaultAsync(ur => ur.UserId == userRoleDTO.UserId && ur.RoleId == userRoleDTO.RoleId && ur.IsActive);

                if (existingUserRole != null)
                {
                    throw new Exception("User already has this role");
                }

                var userRole = new UserRole
                {
                    UserId = userRoleDTO.UserId,
                    RoleId = userRoleDTO.RoleId,
                };

                _context.UserRoles.Add(userRole);
                await _context.SaveChangesAsync();

                return ServiceResults<UserRole>.Success(userRole);
            }
            catch (Exception ex)
            {
                return ServiceResults<UserRole>.Failure(ex.Message);
            }
        }

        public async Task<ServiceResults<UserRole>> RevokeRoleFromUser(UserRoleDTO userRoleDTO)
        {
            try
            {
                var userRole = await _context.UserRoles
                    .FirstOrDefaultAsync(ur => ur.UserId == userRoleDTO.UserId && ur.RoleId == userRoleDTO.RoleId && ur.IsActive);

                if (userRole == null)
                {
                    return ServiceResults<UserRole>.Failure("User role assignment not found or already revoked");
                }

                userRole.IsActive = false;
                
                await _context.SaveChangesAsync();
                return ServiceResults<UserRole>.Success(userRole);
            }
            catch (Exception ex)
            {
                return ServiceResults<UserRole>.Failure(ex.Message);
            }
        }
    }
}
