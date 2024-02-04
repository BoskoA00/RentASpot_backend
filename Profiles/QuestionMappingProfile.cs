<<<<<<< HEAD
﻿using AutoMapper;
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
=======
﻿using AutoMapper;
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
>>>>>>> 2841b6ef995917dae6568bacd207e8620aa7bae9
