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

        [MaxLength(200)]
        public string? Description { get; set; }

        [Required(ErrorMessage = "Url Image is required")]
        [MaxLength(250)]
        public string? UrlImage { get; set; }

        [Required(ErrorMessage = "Url Thumbnail is required")]
        [MaxLength(250)]
        public string? UrlThumbnail { get; set; }

        [Required(ErrorMessage = "Enter the creation date")]
        public DateTime CreatedAt { get; private set; }
    }
}
