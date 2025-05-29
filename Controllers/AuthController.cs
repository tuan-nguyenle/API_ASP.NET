using ASP.Net.DTOs.AuthDTOs;
using ASP.Net.Entities;
using ASP.Net.Services.AuthServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASP.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService _authService) : Controller
    {
        //private static readonly User user = new();
        [HttpPost("Register")]
        public async Task<ActionResult<User>> Register(UserDTO userDTO)
        {
            var results = await _authService.Register(userDTO);

            if (results.IsSuccess)
            {
                return Ok(results.Data);
            }

            //if (results.ValidationErrors.Count > 0)
            //{
            //    return BadRequest(new { results.ValidationErrors });
            //}

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

        [HttpGet("me")]
        [Authorize]
        public ActionResult<string> Me()
        {
            return Ok("Hehehe");
        }
    }
}
