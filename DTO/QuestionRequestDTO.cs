using ProjekatSI.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjekatSI.DTO
{
    public class QuestionRequestDTO
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
    }
}
