using ASP.Net.Data;
using ASP.Net.DTOs.PermissionDTOs;
using ASP.Net.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net.Services.PermissionServices
{
    public class PermissionService(AuthDbContext context, IMapper mapper) : IPermissionService
    {
        private readonly AuthDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task<ServiceResults<Permission>> CreatePermission(PermissionDTO permissionDTO)
        {
            try
            {
                var existingPermission = await _context.Permissions
                    .FirstOrDefaultAsync(p => p.Action == permissionDTO.Action);

                if (existingPermission != null)
                {
                    throw new Exception("Permission with this action already exists");
                }

                var permission = _mapper.Map<Permission>(permissionDTO);

                _context.Permissions.Add(permission);
                await _context.SaveChangesAsync();

                return ServiceResults<Permission>.Success(permission);

            }
            catch (Exception ex)
            {
                return ServiceResults<Permission>.Failure(ex.Message);
            }
        }

    }
}
