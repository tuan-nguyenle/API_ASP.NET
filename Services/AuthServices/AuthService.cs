using ASP.Net.Data;
using ASP.Net.DTOs.AuthDTOs;
using ASP.Net.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASP.Net.Services.AuthServices
{
    public class AuthService(AuthDbContext context, IConfiguration configuration, IMapper mapper) : IAuthService
    {
        private readonly AuthDbContext _context = context;
        private readonly IConfiguration _configuration = configuration;
        private readonly IMapper _mapper = mapper;

        public async Task<ServiceResults<User>> Register(UserDTO userDTO)
        {
            try
            {
                var existingUser = await _context.Users
                    .FirstOrDefaultAsync(
                        u => (u.Email == userDTO.Email) || (u.Username == userDTO.Username)
                    );

                if (existingUser != null)
                {
                    var field = string.Equals(existingUser.Email, userDTO.Email, StringComparison.OrdinalIgnoreCase) ? "email" : "username";
                    throw new Exception($"User with this {field} already exists");
                }

                var user = _mapper.Map<User>(userDTO);

                user.Password = new PasswordHasher<User>().HashPassword(user, userDTO.Password);

                _context.Users.Add(user);

                await _context.SaveChangesAsync();

                return ServiceResults<User>.Success(user);
            }
            catch (Exception ex)
            {
                return ServiceResults<User>.Failure(ex.Message);
            }
        }

        public async Task<ServiceResults<string>> Login(LoginDTO loginDTO)
        {
            try
            {
                var user = await _context.Users
                        .FirstOrDefaultAsync(
                            u => (u.Username == loginDTO.Username)
                        );

                if (user is null || new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, loginDTO.Password) == PasswordVerificationResult.Failed)
                {
                    throw new Exception("Invalid username or password");
                }

                return ServiceResults<string>.Success(CreateToken(user));
            }
            catch (Exception ex)
            {
                return ServiceResults<string>.Failure(ex.Message);
            }
        }

        private string CreateToken(User user)
        {
            var jwtSecret = _configuration.GetValue<string>("AppSettings:JWT_SECRET");
            if (string.IsNullOrEmpty(jwtSecret))
            {
                throw new InvalidOperationException("JWT_SECRET is not configured in AppSettings.");
            }

            var claims = new List<Claim>
            {
                new (ClaimTypes.NameIdentifier,user.Id.ToString()),
                new (ClaimTypes.Name,user.Username),
            };

            var jwtToken = new JwtSecurityToken(
                claims: claims,
                issuer: _configuration.GetValue<string>("AppSettings:ISSUER"),
                audience: _configuration.GetValue<string>("AppSettings:AUDIENCE"),
                expires: DateTime.UtcNow.AddMinutes(_configuration.GetValue<int>("AppSettings:JWT_Expired")),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(jwtSecret)
                        ),
                        SecurityAlgorithms.HmacSha256Signature
                    )
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
