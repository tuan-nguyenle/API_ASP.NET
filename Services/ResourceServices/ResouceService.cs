using ASP.Net.Data;
using ASP.Net.DTOs.AuthDTOs;
using ASP.Net.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ASP.Net.Services.ResourceServices
{
    public class ResouceService(AuthDbContext context, IMapper mapper) : IResouceService
    {
        private readonly AuthDbContext _context = context;
        private readonly IMapper _mapper = mapper;
        public async Task<ServiceResults<Resource>> CreateResource(ResourceDTO resourceDTO)
        {
            try
            {
                var existingResource = await _context.Resources
                    .FirstOrDefaultAsync(r => r.Path == resourceDTO.Path);

                if (existingResource != null)
                {
                    throw new Exception("Resource with this path already exists");
                }

                var resource = _mapper.Map<Resource>(resourceDTO);

                _context.Resources.Add(resource);
                await _context.SaveChangesAsync();

                return ServiceResults<Resource>.Success(resource);
            }
            catch (Exception ex)
            {
                return ServiceResults<Resource>.Failure(ex.Message);
            }
        }
    }
}
