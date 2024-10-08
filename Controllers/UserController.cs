using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjekatSI.Data;
using ProjekatSI.DTO;
using ProjekatSI.Interface;
using System.Data.SqlTypes;
using System.Security.Claims;


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

            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var user = _mapper.Map<User>(request);
            
            if (int.Parse(userRole) != (int)UserRoles.Admin)
            {
                var idToken = User.FindFirst("id")?.Value;
                if (int.Parse(idToken) != user.Id)
                {
                    return Forbid();
                }

            }


            user.Password = _userService.HashPassword(request.Password);
            await _userService.UpdateUser(user);

            return Ok(_mapper.Map<UserResponseDTO>(await _userService.GetUserById(user.Id)));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser([FromRoute] int id)
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;
            
            var user = _mapper.Map<User>(await _userService.GetUserById(id));
            if (int.Parse(userRole) != (int)UserRoles.Admin)
            {
                var idToken = User.FindFirst("id")?.Value;
                if(int.Parse(idToken) != user.Id)
                {
                    return Forbid();
                }

            }

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
                    Message = " User already exists."
                });
            }
            bool provera =await _userService.CheckPassword(_userService.HashPassword(request.Password));
            if(provera)
            {
                return BadRequest(new ErrorResponseDTO
                {
                    Message = "Password taken"
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
                    Message = "This user doesn't exist."
                });
            }
            if (_userService.HashPassword(request.Password) != userExists.Password)
            {
                return BadRequest(new ErrorResponseDTO
                {
                    Message = "Bad data."
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
