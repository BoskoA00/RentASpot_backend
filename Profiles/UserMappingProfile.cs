<<<<<<< HEAD
﻿using AutoMapper;
using ProjekatSI.Data;
using ProjekatSI.DTO;

namespace ProjekatSI.Profiles
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User,UserResponseDTO>();
            CreateMap<UserRequestDTO, User>();   
            CreateMap<User,UserResponseExtraDTO>();
            CreateMap<RegisterRequestDTO, User>();
        }
    }
}
=======
﻿using AutoMapper;
using ProjekatSI.Data;
using ProjekatSI.DTO;

namespace ProjekatSI.Profiles
{
    public class UserMappingProfile:Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User,UserResponseDTO>();
            CreateMap<UserRequestDTO, User>();   
            CreateMap<User,UserResponseExtraDTO>();
            CreateMap<RegisterRequestDTO, User>();
        }
    }
}
>>>>>>> 2841b6ef995917dae6568bacd207e8620aa7bae9
