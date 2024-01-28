using ProjekatSI.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjekatSI.DTO
{
    public class OglasResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PicturePath { get; set; }
        public int Price { get; set; }
        public float Size { get; set; }
        public int Type { get; set; }
        public int UserId { get; set; }
        public UserResponseExtraDTO User{ get; set; }

    }
}
