using ProjekatSI.Data;

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
