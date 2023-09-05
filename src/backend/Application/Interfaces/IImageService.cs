using Application.DTOs;

namespace Application.Interfaces
{
    public interface IImageService
    {
        Task<IEnumerable<ImageDTO>> GetImages();
        Task<ImageDTO> GetById(int? id);
        Task Add(ImageDTO imageDTO);
        Task Update(ImageDTO imageDTO);
        Task Remove(int? id);
    }
}
