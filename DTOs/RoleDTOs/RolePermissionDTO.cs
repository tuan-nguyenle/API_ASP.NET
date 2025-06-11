using System.ComponentModel.DataAnnotations;

namespace ASP.Net.DTOs.RoleDTOs
{
    public class RolePermissionDTO
    {
        [Required]
        public int RoleId { get; set; }

        [Required]
        public int PermissionId { get; set; }

        public int? ResourceId { get; set; }
    }
}
