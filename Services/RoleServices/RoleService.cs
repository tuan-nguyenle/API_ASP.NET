using ASP.Net.Data;
using ASP.Net.DTOs.AuthDTOs;
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
    }
}
