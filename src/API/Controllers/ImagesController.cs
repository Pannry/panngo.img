using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/[Controller]")]
    [ApiController]
    public class ImagesController : Controller
    {
        private readonly IImageService _imagesService;

        public ImagesController(IImageService imagesService)
        {
            _imagesService = imagesService;
        }

        // api/pictures
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageDTO>>> Get()
        {
            var images = await _imagesService.GetImages();
            return Ok(images);
        }

        [HttpGet("{id}", Name = "GetImages")]
        public async Task<ActionResult<ImageDTO>> Get(int id)
        {
            var image = await _imagesService.GetById(id);

            if (image == null)
            {
                return NotFound();
            }
            return Ok(image);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ImageDTO imageDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _imagesService.Add(imageDto);

            return new CreatedAtRouteResult("GetImages", new { id = imageDto.Id }, imageDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ImageDTO imagesDto)
        {
            if (id != imagesDto.Id)
            {
                return BadRequest();
            }

            await _imagesService.Update(imagesDto);

            return Ok(imagesDto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ImageDTO>> Delete(int id)
        {
            var imagesDto = await _imagesService.GetById(id);
            if (imagesDto == null)
            {
                return NotFound();
            }
            await _imagesService.Remove(id);
            return Ok(imagesDto);
        }
    }
}
