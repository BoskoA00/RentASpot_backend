using AutoMapper;
using ProjekatSI.Data;
using ProjekatSI.DTO;

namespace ProjekatSI.Profiles
{
    public class QuestionMappingProfile:Profile
    {
        public QuestionMappingProfile()
        {
            CreateMap<Question, QuestionResponseDTO>();
            CreateMap<QuestionRequestDTO, Question>();
            CreateMap<Question, QuestionUpdateDTO>();
            CreateMap<QuestionUpdateDTO, Question>();
            CreateMap<QuestionWA, Question>();
            CreateMap<Question, QuestionWA>();
        }
    }
}
