using AutoMapper;
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
