using ProjekatSI.Data;

namespace ProjekatSI.DTO
{
    public class QuestionExtraDTO
    {
        public int Id { get; set; }
        public int Content { get; set; }
        public List<QuestionAnswer> Answers { get;}
    }
}
