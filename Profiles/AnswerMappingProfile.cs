<<<<<<< HEAD
﻿using AutoMapper;
using ProjekatSI.Data;
using ProjekatSI.DTO;

namespace ProjekatSI.Profiles
{
    public class AnswerMappingProfile : Profile
    {
        public AnswerMappingProfile()
        {
            CreateMap<QuestionAnswer, AnswerRequestDTO>();
=======
﻿using AutoMapper;
using ProjekatSI.Data;
using ProjekatSI.DTO;

namespace ProjekatSI.Profiles
{
    public class AnswerMappingProfile : Profile
    {
        public AnswerMappingProfile()
        {
            CreateMap<QuestionAnswer, AnswerRequestDTO>();
>>>>>>> 2841b6ef995917dae6568bacd207e8620aa7bae9
            CreateMap<AnswerRequestDTO, QuestionAnswer>();
            CreateMap<QuestionAnswer,AnswerResponseDTO>();
            CreateMap<AnswerResponseDTO,QuestionAnswer>();
            CreateMap<QuestionAnswer, AnswerUpdateDTO>();
            CreateMap<AnswerUpdateDTO, QuestionAnswer>();
<<<<<<< HEAD
        }
    }
}
=======
        }
    }
}
>>>>>>> 2841b6ef995917dae6568bacd207e8620aa7bae9
