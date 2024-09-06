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
using System.Security.Claims;

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

            if (!User.Claims.Any()) {
                return Forbid();
            }
            
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            

            if (int.Parse(userRole) == (int)UserRoles.Buyer)
            {
                return Forbid();
            }


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

            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var adFromDatabase =await _adService.GetAdById(id);


            if (int.Parse(userRole) == (int)UserRoles.Buyer)
            {
                return Forbid();
            }


            if (int.Parse(userRole) != (int)UserRoles.Admin)
            {
                var idToken = User.FindFirst("id")?.Value;
                
                if(int.Parse(idToken) != adFromDatabase.UserId)
                {
                return Forbid();
                }
            }
            if(adFromDatabase == null)
            {
                return BadRequest(new ErrorResponseDTO{
                    Message="This ad doesn't exist."
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
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;


            if (int.Parse(userRole) == (int)UserRoles.Buyer)
            {
                return Forbid();
            }


            if (int.Parse(userRole) != (int)UserRoles.Admin)
            {
                var idToken = User.FindFirst("id")?.Value;

                if (int.Parse(idToken) != ad.UserId)
                {
                    return Forbid();
                }
            }

            if (ad == null)
            {
                return NotFound(new ErrorResponseDTO
                {
                    Message = "Ad not found."
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
