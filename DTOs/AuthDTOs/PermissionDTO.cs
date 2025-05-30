using System.ComponentModel.DataAnnotations;

namespace ASP.Net.DTOs.AuthDTOs
{
    public class PermissionDTO
    {
        [Required]
        [StringLength(50)]
        public string Action { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
    }
}
