using AutoMapper;
using ProjekatSI.Data;
using ProjekatSI.DTO;

namespace ProjekatSI.Profiles
{
    public class OglasMappingProfile :Profile
    {
        public OglasMappingProfile()
        {
            CreateMap<Oglas, OglasResponseDTO>();
            CreateMap<OglasRequestDTO, Oglas>();
            CreateMap<OglasUpdateRequestDTO, Oglas>();
            CreateMap<OglasResponseExtraDTO, Oglas>();
            CreateMap<Oglas, OglasResponseExtraDTO>();
            CreateMap<Oglas, OglasUpdateRequestDTO>();
        }
    }
}
