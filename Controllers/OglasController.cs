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
    public class OglasController : ControllerBase
    {
        private readonly IOglasInteface _oglasService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUserInterface _userInterface;
        public OglasController(IOglasInteface oglasService, IMapper mapper, IWebHostEnvironment webHostEnvironment, IUserInterface userInterface)
        {
            _oglasService = oglasService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _userInterface = userInterface;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllOglase()
        {
            return Ok(_mapper.Map<List<OglasResponseDTO>>(await _oglasService.GetAllOglaseAsync()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOneOglas([FromRoute] int id)
        {
            return Ok(_mapper.Map<OglasResponseDTO>(await _oglasService.GetOneOglas(id)));
        }
        [HttpGet("/OglasiByUser/{id}")]
        public async Task<IActionResult> GetAllOglase([FromRoute] int id)
        {
            return Ok(_mapper.Map<List<OglasResponseDTO>>(await _oglasService.GetOglasBtyUser(id)));
        }
     
        [HttpPost]
        public async Task<IActionResult> CreateOglas([FromForm] OglasRequestDTO request)
        {
            Stream fileStream = new FileStream(_webHostEnvironment.WebRootPath + "\\Oglasi\\" + request.PicturePath, FileMode.Create);
            var oglas = _mapper.Map<Oglas>(request);
            if (request.Picture != null)
            {
                request.Picture.CopyTo(fileStream);
                fileStream.Flush();
            }
            await _oglasService.AddOglas(oglas);

            return Ok(oglas);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOglas([FromRoute] int id, [FromBody] OglasUpdateRequestDTO request)
        {
            var oglasFromDatabase =await _oglasService.GetOneOglas(id);
            if(oglasFromDatabase == null)
            {
                return BadRequest(new ErrorResponseDTO{
                    Message="Nema ovog oglasa"
                });
            }

            _mapper.Map<OglasUpdateRequestDTO, Oglas>(request, oglasFromDatabase);

            await _oglasService.UpdateOglas(oglasFromDatabase);

            return Ok(_mapper.Map<OglasResponseDTO>(oglasFromDatabase));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOglas([FromRoute] int id)
        {
            var oglas = await _oglasService.GetOneOglas(id);

            if (oglas == null)
            {
                return NotFound(new ErrorResponseDTO
                {
                    Message = "Oglas not found"
                });
            }

            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "Oglasi", oglas.PicturePath);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            await _oglasService.DeleteOglas(oglas);

            return NoContent();
        }


    }
}
