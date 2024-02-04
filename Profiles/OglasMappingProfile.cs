<<<<<<< HEAD
﻿using AutoMapper;
using ProjekatSI.Data;
using ProjekatSI.DTO;

namespace ProjekatSI.Profiles
{
    public class OglasMappingProfile :Profile
    {
=======
﻿using AutoMapper;
using ProjekatSI.Data;
using ProjekatSI.DTO;

namespace ProjekatSI.Profiles
{
    public class OglasMappingProfile :Profile
    {
>>>>>>> 2841b6ef995917dae6568bacd207e8620aa7bae9
        public OglasMappingProfile()
        {
            CreateMap<Oglas, OglasResponseDTO>();
            CreateMap<OglasRequestDTO, Oglas>();
            CreateMap<OglasUpdateRequestDTO, Oglas>();
            CreateMap<OglasResponseExtraDTO, Oglas>();
            CreateMap<Oglas, OglasResponseExtraDTO>();
            CreateMap<Oglas, OglasUpdateRequestDTO>();
<<<<<<< HEAD
        }
    }
}
=======
        }
    }
}
>>>>>>> 2841b6ef995917dae6568bacd207e8620aa7bae9
