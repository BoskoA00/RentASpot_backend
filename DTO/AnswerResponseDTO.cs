using ProjekatSI.Data;

namespace ProjekatSI.DTO
{
    public class AnswerResponseDTO
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int QuestionId { get; set; }
        public UserResponseExtraDTO User { get; set; }
        public QuestionWA Question { get; set; }
    }
}
