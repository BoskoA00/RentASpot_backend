using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using ProjekatSI.Data;
using ProjekatSI.DTO;
using ProjekatSI.Interface;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;

namespace ProjekatSI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionController : ControllerBase
    {
        private IQuestionInterface _questionService;
        private IMapper _mapper;
        public QuestionController(IQuestionInterface questionService, IMapper mapper)
        {
            _questionService = questionService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            return Ok(_mapper.Map<List<QuestionResponseDTO>>(await _questionService.GetAllQuestionsAsync()));
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById([FromRoute] int id)
        {
            return Ok(_mapper.Map<QuestionResponseDTO>(await _questionService.GetQuestionById(id)));
        }
        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody] QuestionRequestDTO request)
        {

            if (!User.Claims.Any())
            {
                return Forbid();

            }

            var question = _mapper.Map<Question>(request);
            await _questionService.CreateQuestion(question);

            return Ok(_mapper.Map<QuestionResponseDTO>(question));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion([FromRoute] int id, [FromBody] QuestionUpdateDTO request)
        {

            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var question = await _questionService.GetQuestionById(id);

            if (int.Parse(userRole) != (int)UserRoles.Admin)
            {
                var idToken = User.FindFirst("id")?.Value;
                if (int.Parse(idToken) != question.UserId)
                {
                    return Forbid();
                }

            }

            _mapper.Map<QuestionUpdateDTO, Question>(request, question);
            await _questionService.UpdateQuestion(question);

            return Ok(_mapper.Map<QuestionResponseDTO>(question));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion([FromRoute] int id)
        {

            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            var question = await _questionService.GetQuestionById(id); ;
           
            if (int.Parse(userRole) != (int)UserRoles.Admin)
            {
                var idToken = User.FindFirst("id")?.Value;
                if (int.Parse(idToken) != question.UserId)
                {
                    return Forbid();
                }

            }

            await _questionService.DeleteQuestion(question);
            return NoContent();
        }
        

    }
}
