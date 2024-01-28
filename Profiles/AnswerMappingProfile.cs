using AutoMapper;
using ProjekatSI.Data;
using ProjekatSI.DTO;

namespace ProjekatSI.Profiles
{
    public class AnswerMappingProfile : Profile
    {
        public AnswerMappingProfile()
        {
            CreateMap<QuestionAnswer, AnswerRequestDTO>();
            CreateMap<AnswerRequestDTO, QuestionAnswer>();
            CreateMap<QuestionAnswer,AnswerResponseDTO>();
            CreateMap<AnswerResponseDTO,QuestionAnswer>();
            CreateMap<QuestionAnswer, AnswerUpdateDTO>();
            CreateMap<AnswerUpdateDTO, QuestionAnswer>();
        }
    }
}
