using System.ComponentModel.DataAnnotations;

namespace ASP.Net.DTOs.RoleDTOs
{
    public class RoleDTO
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
    }
}
