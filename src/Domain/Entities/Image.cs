using Domain.Validation;

namespace Domain.Entities
{
    public sealed class Image : Entity
    {
        public string? Name { get; private set; }
        public string? Description { get; private set; }
        public string? UrlImage { get; private set; }
        public string? UrlThumbnail { get; private set; }
        public DateTime CreatedAt { get; private set; }

        public Image(string name, string description, string urlImage, string urlThumbnail)
        {
            Description = description;
            ValidateDomain(name, urlImage, urlThumbnail, DateTime.Now);
        }

        public void Update(string name, string description, string urlImage,
            string urlThumbnail, DateTime createdAt)
        {
            Description = description;
            ValidateDomain(name, urlImage, urlThumbnail, createdAt);
        }

        private void ValidateDomain(string name, string urlImage, string urlThumbnail, 
            DateTime createdAt)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required.");

            DomainExceptionValidation.When(name.Length < 3,
                "Name field must be at least 3 characters.");

            DomainExceptionValidation.When(urlImage.Length < 5,
                "Name field must be at least 5 characters.");

            DomainExceptionValidation.When(urlImage?.Length > 250,
                "Image name cannot exceed 250 characters.");

            DomainExceptionValidation.When(urlThumbnail?.Length > 250,
                "Thumbnail name cannot exceed 250 characters.");

            DomainExceptionValidation.When(int.Parse(createdAt.ToString("yyyyMMdd")) <= 0,
                "Image creation date must be valid.");

            Name = name;
            UrlImage = urlImage;
            UrlThumbnail = urlThumbnail;
            CreatedAt = createdAt;
        }
    }
}
