using System.ComponentModel.DataAnnotations;

namespace ASP.Net.DTOs.RoleDTOs
{
    public class UserRoleDTO
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int RoleId { get; set; }
    }
}
