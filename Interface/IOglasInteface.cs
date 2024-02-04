<<<<<<< HEAD
﻿using ProjekatSI.Data;

namespace ProjekatSI.Interface
{
    public interface IOglasInteface
    {
        Task<List<Oglas>> GetAllOglaseAsync();
        Task<Oglas?> GetOneOglas(int id );
        Task DeleteOglas(Oglas oglas);
        Task UpdateOglas(Oglas oglas);
        Task AddOglas(Oglas oglas);
        Task<List<Oglas>> GetOglasBtyUser(int id);
    }
}
=======
﻿using ProjekatSI.Data;

namespace ProjekatSI.Interface
{
    public interface IOglasInteface
    {
        Task<List<Oglas>> GetAllOglaseAsync();
        Task<Oglas?> GetOneOglas(int id );
        Task DeleteOglas(Oglas oglas);
        Task UpdateOglas(Oglas oglas);
        Task AddOglas(Oglas oglas);
        Task<List<Oglas>> GetOglasBtyUser(int id);
    }
}
>>>>>>> 2841b6ef995917dae6568bacd207e8620aa7bae9
