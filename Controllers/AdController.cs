using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjekatSI.Data;
using ProjekatSI.DTO;
using ProjekatSI.Interface;
using ProjekatSI.Service;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace ProjekatSI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdController : ControllerBase
    {
        private readonly IAdInteface _adService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUserInterface _userInterface;
        public AdController(IAdInteface adService, IMapper mapper, IWebHostEnvironment webHostEnvironment, IUserInterface userInterface)
        {
            _adService = adService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _userInterface = userInterface;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOglase()
        {
            return Ok(_mapper.Map<List<AdResponseDTO>>(await _adService.GetAllAds()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneOglas([FromRoute] int id)
        {
            return Ok(_mapper.Map<AdResponseDTO>(await _adService.GetAdById(id)));
        }
        [HttpGet("/AdsByUser/{id}")]
        public async Task<IActionResult> GetAllOglase([FromRoute] int id)
        {
            return Ok(_mapper.Map<List<AdResponseDTO>>(await _adService.GetAdByUserId(id)));
        }

        [HttpPost]
        public async Task<IActionResult> CreateOglas([FromForm] AdRequestDTO request)
        {
            string directoryPath = Path.Combine(_webHostEnvironment.WebRootPath, "Ads");
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            string filePath = Path.Combine(directoryPath, request.PicturePath);

            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                if (request.Picture != null)
                {
                    await request.Picture.CopyToAsync(fileStream);
                    fileStream.Flush();
                }
            }

            var ad = _mapper.Map<Ad>(request);

            await _adService.AddAd(ad);

            return Ok(ad);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOglas([FromRoute] int id, [FromBody] AdUpdateRequestDTO request)
        {
            var adFromDatabase =await _adService.GetAdById(id);
            if(adFromDatabase == null)
            {
                return BadRequest(new ErrorResponseDTO{
                    Message="Nema ovog oglasa"
                });
            }

            _mapper.Map<AdUpdateRequestDTO, Ad>(request, adFromDatabase);

            await _adService.UpdateAd(adFromDatabase);

            return Ok(_mapper.Map<AdResponseDTO>(adFromDatabase));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOglas([FromRoute] int id)
        {
            var ad = await _adService.GetAdById(id);

            if (ad == null)
            {
                return NotFound(new ErrorResponseDTO
                {
                    Message = "Oglas not found"
                });
            }

            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Ads", ad.PicturePath);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            await _adService.DeleteAd(ad);

            return NoContent();
        }


    }
}
