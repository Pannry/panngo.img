using Application.DTOs;
using Application.Interfaces;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class ImageService : IImageService
    {
        private IImageRepository _imageRepository;

        private readonly IMapper _mapper;
        public ImageService(IMapper mapper, IImageRepository imageRepository)
        {
            _imageRepository = imageRepository ??
                 throw new ArgumentNullException(nameof(imageRepository));

            _mapper = mapper;
        }

        public async Task<IEnumerable<ImageDTO>> GetImages()
        {
            var imagesEntity = await _imageRepository.GetListAsync();
            return _mapper.Map<IEnumerable<ImageDTO>>(imagesEntity);
        }

        public async Task<ImageDTO> GetById(int? id)
        {
            var imageEntity = await _imageRepository.GetByIdAsync(id);
            return _mapper.Map<ImageDTO>(imageEntity);
        }

        public async Task Add(ImageDTO imagesDto)
        {
            var imageEntity = _mapper.Map<Image>(imagesDto);
            await _imageRepository.CreateAsync(imageEntity);
        }

        public async Task Update(ImageDTO imageDto)
        {

            var imageEntity = _mapper.Map<Image>(imageDto);
            await _imageRepository.UpdateAsync(imageEntity);
        }

        public async Task Remove(int? id)
        {
            var imageEntity = _imageRepository.GetByIdAsync(id).Result;
            await _imageRepository.RemoveAsync(imageEntity);
        }
    }
}
