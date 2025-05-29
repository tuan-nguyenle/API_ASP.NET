using System.ComponentModel.DataAnnotations;

namespace ASP.Net.DTOs.AuthDTOs
{
    public class UserDTO
    {
        [Required]
        [StringLength(100)]
        public string Username { get; set; } = string.Empty;
        [Required]
        [StringLength(100, MinimumLength = 8)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string Email { get; set; } = string.Empty;
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;
    }
}
