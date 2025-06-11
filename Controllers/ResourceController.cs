using ASP.Net.DTOs.AuthDTOs;
using ASP.Net.Entities;
using ASP.Net.Services.ResourceServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ASP.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ResourceController(IResouceService _resouceService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Resource>> CreateResource(ResourceDTO resourceDTO)
        {
            var result = await _resouceService.CreateResource(resourceDTO);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.ErrorMessage);
        }
    }
}
