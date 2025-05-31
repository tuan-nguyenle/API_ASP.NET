using ASP.Net.DTOs.AuthDTOs;
using ASP.Net.Entities;
using ASP.Net.Services.PermissionServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PermissionController(IPermissionService _permissionService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Permission>> CreatePermission(PermissionDTO permissionDTO)
        {
            var results = await _permissionService.CreatePermission(permissionDTO);

            if (results.IsSuccess)
            {
                return Ok(results.Data);
            }

            return BadRequest(results.ErrorMessage);
        }
    }
}