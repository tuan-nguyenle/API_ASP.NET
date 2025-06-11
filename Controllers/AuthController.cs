using ASP.Net.DTOs.AuthDTOs;
using ASP.Net.Entities;
using ASP.Net.Services.AuthServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ASP.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService _authService) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserDTO userDTO)
        {
            var results = await _authService.Register(userDTO);

            if (results.IsSuccess)
            {
                return Ok(results.Data);
            }

            return BadRequest(results.ErrorMessage);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<string>> Login(LoginDTO loginDTO)
        {
            var results = await _authService.Login(loginDTO);

            if (!results.IsSuccess)
            {
                return BadRequest(results.ErrorMessage);
            }

            return Ok(results.Data);
        }

        [HttpGet("Profile/{username}")]
        [Authorize]
        public async Task<ActionResult<User>> Profile(string username)
        {
            var results = await _authService.GetUser(username);

            if (!results.IsSuccess)
            {
                return BadRequest(results.ErrorMessage);
            }

            return Ok(results.Data);
        }
    }
}
