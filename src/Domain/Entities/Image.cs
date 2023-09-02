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

        public Image(string name, string description, string urlImage,
            string urlThumbnail, DateTime createdAt)
        {
            ValidateDomain(name, description, urlImage, urlThumbnail, createdAt);
        }

        public void Update(string name, string description, string urlImage,
            string urlThumbnail, DateTime createdAt)
        {
            ValidateDomain(name, description, urlImage, urlThumbnail, createdAt);
        }

        private void ValidateDomain(string name, string description, string urlImage,
            string urlThumbnail, DateTime createdAt)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name),
                "Nome inválido. O nome é obrigatório");

            DomainExceptionValidation.When(name.Length < 3,
                "O nome deve ter no mínimo 3 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(description),
                "Descrição inválida. A descrição é obrigatória");

            DomainExceptionValidation.When(urlImage.Length < 5,
                "A descrição deve ter no mínimo 5 caracteres");

            DomainExceptionValidation.When(urlImage?.Length > 250,
                "O nome da imagem não pode exceder 250 caracteres");

            DomainExceptionValidation.When(urlThumbnail?.Length > 250,
                "O nome da imagem não pode exceder 250 caracteres");

            DomainExceptionValidation.When(int.Parse(createdAt.ToString("yyyyMMdd")) > 0,
                "O nome da imagem não pode exceder 250 caracteres");

            Name = name;
            Description = description;
            UrlImage = urlImage;
            UrlThumbnail = urlThumbnail;
            CreatedAt = createdAt;
        }
    }
}
