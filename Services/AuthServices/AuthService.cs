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
    public class AuthService(UserDbContext context, IConfiguration configuration, IMapper mapper) : IAuthService
    {
        private readonly UserDbContext _context = context;
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
                    return ServiceResults<User>.Failure($"User with this {field} already exists");
                }

                var user = _mapper.Map<User>(userDTO);

                user.Password = new PasswordHasher<User>().HashPassword(user, userDTO.Password);
                user.Created_At = DateTime.UtcNow;
                user.Updated_At = DateTime.UtcNow;

                _context.Users.Add(user);

                await _context.SaveChangesAsync();

                return ServiceResults<User>.Success(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return ServiceResults<User>.Failure("An error occurred during registration");
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
                if (user is null)
                {
                    return ServiceResults<string>.Failure("Not Found Username");
                }

                if (new PasswordHasher<User>().VerifyHashedPassword(user, user.Password, loginDTO.Password) == PasswordVerificationResult.Failed)
                {
                    return ServiceResults<string>.Failure("Wrong Username / Password");
                }

                return ServiceResults<string>.Success(CreateToken(user));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return ServiceResults<string>.Failure("An error occurred during Login");
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
