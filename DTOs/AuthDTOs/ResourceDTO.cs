using System.ComponentModel.DataAnnotations;

namespace ASP.Net.DTOs.AuthDTOs
{
    public class ResourceDTO
    {
        [Required]
        public string Path { get; set; } = string.Empty;
        [Required]
        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
        [Required]
        public int Priority { get; set; }
        [Required]
        public string Icon { get; set; } = string.Empty;
        public int ParentId { get; set; }
    }
}
