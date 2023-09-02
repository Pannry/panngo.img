using System.ComponentModel.DataAnnotations;

namespace Application.DTOs
{
    public class ImageDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MinLength(3)]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MinLength(5)]
        [MaxLength(200)]
        public string? Description { get; set; }

        [MaxLength(250)]
        public string? UrlImage { get; private set; }

        [MaxLength(250)]
        public string? UrlThumbnail { get; private set; }

        [Required(ErrorMessage = "Enter the creation date")]
        public DateTime CreatedAt { get; private set; }
    }
}
