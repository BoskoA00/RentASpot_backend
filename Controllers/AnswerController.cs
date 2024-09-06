using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjekatSI.Data;
using ProjekatSI.DTO;
using ProjekatSI.Interface;
using System.Security.Claims;

namespace ProjekatSI.Controllers
{
    [ApiController]
    public class AnswerController : ControllerBase
    {
        IAnswerIntefrace _answerService;
        IMapper _mapper;

        public AnswerController(IAnswerIntefrace answerIntefrace, IMapper mapper)
        {
            _answerService = answerIntefrace;
            _mapper = mapper;
        }
        [HttpGet("api/[controller]")]
        public async Task<IActionResult> GetAllAnswers()
        {
            return Ok(_mapper.Map<List<AnswerResponseDTO>>(await _answerService.GetAllAnswersAsync()));
        }
        [HttpGet("api/Question/{id}/Answers")]
        public async Task<IActionResult> GetAnswersByQuestionId([FromRoute] int id)
        {
            return Ok(_mapper.Map<List<AnswerResponseDTO>>(await _answerService.GetAllAnswersByQuestion(id)));
        }
        [HttpPost("api/Question/Answers")]
        public async Task<IActionResult> CreateAnswer([FromBody] AnswerRequestDTO request)
        {

            if (!User.Claims.Any()) {
                return Forbid();
            }

            var answer = _mapper.Map<QuestionAnswer>(request);
           
            await _answerService.CreateAnswer(answer);

            return Ok(request);
        }
        [HttpDelete("api/[controller]/{id}")]
        public async Task<IActionResult> DeleteAnswer([FromRoute] int id)
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;

            

            var answer =await _answerService.GetAnswerById(id);
            
            if(int.Parse(userRole) != (int)UserRoles.Admin)
            {
                var idToken = User.FindFirst("id")?.Value;
                if( int.Parse(idToken) != answer.UserId)
                {
                    return Forbid();
                }

            }
            
            await _answerService.DeleteAnswer(answer);
            return NoContent();
        }
        [HttpPut("api/[controller]/{id}")]
        public async Task<IActionResult> UpdateAnswer([FromRoute] int id, [FromBody] AnswerUpdateDTO request)
        {
            var userRole = User.FindFirst(ClaimTypes.Role)?.Value;



            var answer = await _answerService.GetAnswerById(id);

            if (int.Parse(userRole) != (int)UserRoles.Admin)
            {
                var idToken = User.FindFirst("id")?.Value;
                if (int.Parse(idToken) != answer.UserId)
                {
                    return Forbid();
                }

            }

            _mapper.Map<AnswerUpdateDTO,QuestionAnswer>(request,answer);

            return Ok(_mapper.Map<AnswerResponseDTO>(answer));
        }
    }
}
