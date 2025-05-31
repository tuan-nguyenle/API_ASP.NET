using ASP.Net.DTOs.AuthDTOs;
using ASP.Net.Entities;
using ASP.Net.Services.RoleServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RoleController(IRoleService _roleService) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<Role>> CreateRole(RoleDTO roleDTO)
        {
            var result = await _roleService.CreateRole(roleDTO);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.ErrorMessage);
        }
    }
}
