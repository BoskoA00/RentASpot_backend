using Microsoft.EntityFrameworkCore;
using ProjekatSI.Data;
using ProjekatSI.Interface;

namespace ProjekatSI.Service
{
    public class AdService : IAdInteface
    {
        public readonly DatabaseContext _databaseContext;
        
        public AdService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task AddAd(Ad ad)
        {
             _databaseContext.Ads.Add(ad);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteAd(Ad ad)
        {
            _databaseContext.Ads.Remove(ad);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<List<Ad>> GetAllAds()
        {
            return await _databaseContext.Ads.Include( ad => ad.User).ToListAsync();
        }

        public async Task<List<Ad>> GetAdByUserId(int id)
        {
           return await _databaseContext.Ads.Where( ad => ad.UserId == id).ToListAsync();
        }

        public async Task<Ad?> GetAdById(int id)
        {
            return await _databaseContext.Ads.Include( ad => ad.User).FirstOrDefaultAsync( ad => ad.Id == id);
        }

        public async Task UpdateAd(Ad ad)
        {
            _databaseContext.Ads.Update(ad);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
