using ProjekatSI.Data;

namespace ProjekatSI.Interface
{
    public interface IAnswerIntefrace
    {
        public Task<List<QuestionAnswer>> GetAllAnswersAsync();
        public Task<List<QuestionAnswer>> GetAllAnswersByQuestion(int id);
        public Task<QuestionAnswer?> GetAnswerById(int id);
        public Task CreateAnswer(QuestionAnswer question);
        public Task DeleteAnswer(QuestionAnswer question);
        public Task UpdateAnswer(QuestionAnswer question);
    }
}
