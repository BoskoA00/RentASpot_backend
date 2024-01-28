using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjekatSI.Data;
using ProjekatSI.DTO;
using ProjekatSI.Interface;


namespace ProjekatSI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _userService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserController(IUserInterface userService, IMapper mapper, IWebHostEnvironment webHostEnvironment)
        {
            _userService = userService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsersAsync()
        {
            return Ok( _mapper.Map<List<UserResponseDTO>>( await _userService.GetAllUsersAsync()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById([FromRoute] int id)
        {
            return Ok(_mapper.Map<UserResponseDTO>(await _userService.GetUserById(id)));
        }
        [HttpPost("getByUserName")]
        public async Task<IActionResult> GetUserByUserName([FromBody] string userName)
        {
            return Ok(_mapper.Map<UserResponseDTO>(await _userService.GetByUserName(userName)));
        }
        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody] UserRequestDTO request)
        {
            var user = _mapper.Map<User>(request);
            
            await _userService.UpdateUser(user);


            return Ok(_mapper.Map<UserResponseDTO>(await _userService.GetUserById(user.Id)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var user = _mapper.Map<User>(await _userService.GetUserById(id));
            if (user.ImageName != "NoPic.png")
            {

            var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", user.ImageName);

            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }
            }
            await _userService.DeleteUser(user);

            return NoContent();
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser([FromForm] RegisterRequestDTO request)
        {
            var userProvera = await _userService.GetByUserName(request.Email);
            if (userProvera != null)
            {
                return BadRequest(new ErrorResponseDTO
                {
                    Message = "Postoji već korisnik sa ovim imenom"
                });
            }
            bool provera =await _userService.CheckPassword(_userService.HashPassword(request.Password));
            if(provera)
            {
                return BadRequest(new ErrorResponseDTO
                {
                    Message = "Lozinka je zauzeta"
                });
            }
            var user = _mapper.Map<User>(request);

            if (request.Image != null && request.Image.Length > 0)
            {
                using var fileStream = new FileStream(_webHostEnvironment.WebRootPath + "\\Images\\" + request.Email + "-" + request.Image.FileName, FileMode.Create);
                user.ImageName = request.Email + "-" + request.Image.FileName;
                await request.Image.CopyToAsync(fileStream);
            }
            else
            {
                user.ImageName = "NoPic.png";
            }

            user.Password = _userService.HashPassword(request.Password);

            if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Images"))
            {
                Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Images");
            }

            await _userService.RegisterUser(user);

            var token = _userService.GenerateToken(user);

            return Ok(new AuthResponseDTO
            {
                Token = token,
                User = _mapper.Map<UserResponseDTO>(user)
            });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO request)
        {
            var userExists = await _userService.GetByUserName(request.Email);
            if (userExists == null)
            {
                return BadRequest(new ErrorResponseDTO
                {
                    Message = "Ne postoji ovaj korisnik"
                });
            }
            if (_userService.HashPassword(request.Password) != userExists.Password)
            {
                return BadRequest(new ErrorResponseDTO
                {
                    Message = "Neispravni podaci"
                });
            }
            var token = _userService.GenerateToken(userExists);

            return Ok(new AuthResponseDTO
            {
                Token = token,
                User = _mapper.Map<UserResponseDTO>(userExists)
            });

        }
    }
}
