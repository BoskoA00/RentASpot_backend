using ProjekatSI.Data;

namespace ProjekatSI.Interface
{
    public interface IAdInteface
    {
        Task<List<Ad>> GetAllAds();
        Task<Ad?> GetAdById(int id );
        Task DeleteAd(Ad oglas);
        Task UpdateAd(Ad oglas);
        Task AddAd(Ad oglas);
        Task<List<Ad>> GetAdByUserId(int id);
    }
}
