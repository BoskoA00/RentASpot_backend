using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using ProjekatSI.Data;
using ProjekatSI.DTO;
using ProjekatSI.Interface;
using System.Reflection.Metadata.Ecma335;

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
            var r = _mapper.Map<Question>(request);
            await _questionService.CreateQuestion(r);

            return Ok(_mapper.Map<QuestionResponseDTO>(r));
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion([FromRoute] int id, [FromBody] QuestionUpdateDTO request)
        {
            var r = await _questionService.GetQuestionById(id);
            _mapper.Map<QuestionUpdateDTO, Question>(request, r);
            await _questionService.UpdateQuestion(r);

            return Ok(_mapper.Map<QuestionResponseDTO>(r));
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion([FromRoute] int id)
        {
            var q = await _questionService.GetQuestionById(id); ;
            await _questionService.DeleteQuestion(q);
            return NoContent();
        }
        

    }
}
