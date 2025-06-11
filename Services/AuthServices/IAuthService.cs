using ASP.Net.DTOs.AuthDTOs;
using ASP.Net.Entities;

namespace ASP.Net.Services.AuthServices
{
    public interface IAuthService
    {
        Task<ServiceResults<User>> Register(UserDTO userDTO);
        Task<ServiceResults<string>> Login(LoginDTO loginDTO);
        Task<ServiceResults<User>> GetUser(string username);
    }
}
