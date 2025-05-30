using System.ComponentModel.DataAnnotations;

namespace ASP.Net.DTOs.AuthDTOs
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
