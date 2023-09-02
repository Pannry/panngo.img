using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private ApplicationDbContext _context;
        public ImageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Image> GetByIdAsync(int? id)
        {
            return await _context.Images.FindAsync(id);
        }

        public async Task<IEnumerable<Image>> GetListAsync()
        {
            return await _context.Images.ToListAsync();
        }

        public async Task<Image> CreateAsync(Image image)
        {
            _context.Add(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task<Image> RemoveAsync(Image image)
        {
            _context.Remove(image);
            await _context.SaveChangesAsync();
            return image;
        }

        public async Task<Image> UpdateAsync(Image image)
        {
            _context.Update(image);
            await _context.SaveChangesAsync();
            return image;
        }
    }
}
