<<<<<<< HEAD
﻿using ProjekatSI.Data;

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
=======
﻿using ProjekatSI.Data;

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
>>>>>>> 2841b6ef995917dae6568bacd207e8620aa7bae9
