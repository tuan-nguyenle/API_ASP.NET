using ASP.Net.DTOs.AuthDTOs;
using ASP.Net.Entities;

namespace ASP.Net.Services.ResourceServices
{
    public interface IResouceService
    {
        Task<ServiceResults<Resource>> CreateResource(ResourceDTO resourceDTO);

    }
}
