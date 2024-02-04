<<<<<<< HEAD
﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjekatSI.Data;
using ProjekatSI.DTO;
using ProjekatSI.Interface;

namespace ProjekatSI.Controllers
{
    [ApiController]
    public class AnswerController : ControllerBase
    {
        IAnswerIntefrace _answerService;
        IMapper _mapper;

=======
﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjekatSI.Data;
using ProjekatSI.DTO;
using ProjekatSI.Interface;

namespace ProjekatSI.Controllers
{
    [ApiController]
    public class AnswerController : ControllerBase
    {
        IAnswerIntefrace _answerService;
        IMapper _mapper;

>>>>>>> 2841b6ef995917dae6568bacd207e8620aa7bae9
        public AnswerController(IAnswerIntefrace answerIntefrace, IMapper mapper)
        {
            _answerService = answerIntefrace;
            _mapper = mapper;
<<<<<<< HEAD
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
            var q = _mapper.Map<QuestionAnswer>(request);
           
            await _answerService.CreateAnswer(q);

            return Ok(request);
        }
        [HttpDelete("api/[controller]/{id}")]
        public async Task<IActionResult> DeleteAnswer([FromRoute] int id)
        {
            var a =await _answerService.GetAnswerById(id);
            await _answerService.DeleteAnswer(a);
            return NoContent();
        }
        [HttpPut("api/[controller]/{id}")]
        public async Task<IActionResult> UpdateAnswer([FromRoute] int id, [FromBody] AnswerUpdateDTO request)
        {
            var a =await _answerService.GetAnswerById(id);

            _mapper.Map<AnswerUpdateDTO,QuestionAnswer>(request,a);

            return Ok(_mapper.Map<AnswerResponseDTO>(a));
        }
    }
}
=======
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
            var q = _mapper.Map<QuestionAnswer>(request);
           
            await _answerService.CreateAnswer(q);

            return Ok(request);
        }
        [HttpDelete("api/[controller]/{id}")]
        public async Task<IActionResult> DeleteAnswer([FromRoute] int id)
        {
            var a =await _answerService.GetAnswerById(id);
            await _answerService.DeleteAnswer(a);
            return NoContent();
        }
        [HttpPut("api/[controller]/{id}")]
        public async Task<IActionResult> UpdateAnswer([FromRoute] int id, [FromBody] AnswerUpdateDTO request)
        {
            var a =await _answerService.GetAnswerById(id);

            _mapper.Map<AnswerUpdateDTO,QuestionAnswer>(request,a);

            return Ok(_mapper.Map<AnswerResponseDTO>(a));
        }
    }
}
>>>>>>> 2841b6ef995917dae6568bacd207e8620aa7bae9
