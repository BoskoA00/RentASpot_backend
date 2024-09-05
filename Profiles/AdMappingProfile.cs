using AutoMapper;
using ProjekatSI.Data;
using ProjekatSI.DTO;

namespace ProjekatSI.Profiles
{
    public class AdMappingProfile :Profile
    {
        public AdMappingProfile()
        {
            CreateMap<Ad, AdResponseDTO>();
            CreateMap<AdRequestDTO, Ad>();
            CreateMap<AdUpdateRequestDTO, Ad>();
            CreateMap<AdResponseExtraDTO, Ad>();
            CreateMap<Ad, AdResponseExtraDTO>();
            CreateMap<Ad, AdUpdateRequestDTO>();
        }
    }
}
