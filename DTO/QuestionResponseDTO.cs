using ProjekatSI.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjekatSI.DTO
{
    public class QuestionResponseDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public UserResponseExtraDTO User { get; set; }
        public List<AnswerResponseDTO> Answers { get; set; }

    }
}
