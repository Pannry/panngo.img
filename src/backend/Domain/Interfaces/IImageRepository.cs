using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IImageRepository
    {
        Task<IEnumerable<Image>> GetListAsync();
        Task<Image> GetByIdAsync(int? id);
        Task<Image> CreateAsync(Image image);
        Task<Image> UpdateAsync(Image image);
        Task<Image> RemoveAsync(Image image);
    }
}
