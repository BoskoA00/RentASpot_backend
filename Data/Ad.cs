using ProjekatSI.DTO;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjekatSI.Data
{
    public class Ad
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PicturePath { get; set; }
        public int Price { get; set; }
        public float Size { get; set; }
        public int Type { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User User { get; set; }
   
    }
}
