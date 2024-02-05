using Microsoft.EntityFrameworkCore;
using ProjekatSI.Data;
using ProjekatSI.Interface;

namespace ProjekatSI.Service
{
    public class OglasService : IOglasInteface
    {
        public readonly DatabaseContext _databaseContext;
        
        public OglasService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task AddOglas(Oglas oglas)
        {
             _databaseContext.Oglasi.Add(oglas);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteOglas(Oglas oglas)
        {
            _databaseContext.Oglasi.Remove(oglas);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<List<Oglas>> GetAllOglaseAsync()
        {
            return await _databaseContext.Oglasi.Include( x => x.User).ToListAsync();
        }

        public async Task<List<Oglas>> GetOglasBtyUser(int id)
        {
           return await _databaseContext.Oglasi.Where(x=> x.UserId == id).ToListAsync();
        }

        public async Task<Oglas?> GetOneOglas(int id)
        {
            return await _databaseContext.Oglasi.Include(x => x.User).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateOglas(Oglas oglas)
        {
            _databaseContext.Oglasi.Update(oglas);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
