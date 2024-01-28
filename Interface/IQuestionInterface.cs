using ProjekatSI.Data;

namespace ProjekatSI.Interface
{
    public interface IQuestionInterface
    {
        public Task<List<Question>> GetAllQuestionsAsync();
        public Task<Question?> GetQuestionById(int id);
        public Task CreateQuestion(Question question);
        public Task UpdateQuestion(Question question);
        public Task DeleteQuestion(Question question);
        public Task<List<Question>> GetQuestionsByUserId(int id);
    }
}
