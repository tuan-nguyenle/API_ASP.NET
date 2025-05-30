using System.ComponentModel.DataAnnotations;

namespace ASP.Net.DTOs.AuthDTOs
{
    public class UserRoleDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int RoleId { get; set; }
    }
}
