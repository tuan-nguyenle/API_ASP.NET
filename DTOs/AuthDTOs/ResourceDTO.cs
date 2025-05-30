using System.ComponentModel.DataAnnotations;

namespace ASP.Net.DTOs.AuthDTOs
{
    public class ResourceDTO
    {
        [Required]
        public string Path { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; } = string.Empty;
    }
}
