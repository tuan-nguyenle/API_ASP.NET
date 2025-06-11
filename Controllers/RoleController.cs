using ASP.Net.DTOs.RoleDTOs;
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

        [HttpPost("assign")]
        public async Task<IActionResult> AssignRoleToUser(UserRoleDTO userRoleDTO)
        {
            var result = await _roleService.AssignRoleToUser(userRoleDTO);

            if (result.IsSuccess)
            {
                return Ok(new { message = "Role assigned successfully", data = result.Data });
            }

            return BadRequest(new { message = result.ErrorMessage });
        }

        [HttpPost("revoke")]
        public async Task<IActionResult> RevokeRoleFromUser(UserRoleDTO userRoleDTO)
        {
            var result = await _roleService.RevokeRoleFromUser(userRoleDTO);

            if (result.IsSuccess)
            {
                return Ok(new { message = "Role revoked successfully", data = result.Data });
            }

            return BadRequest(new { message = result.ErrorMessage });
        }
    }
}
