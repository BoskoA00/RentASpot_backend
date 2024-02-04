<<<<<<< HEAD
﻿using ProjekatSI.Data;

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
=======
﻿using ProjekatSI.Data;

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
>>>>>>> 2841b6ef995917dae6568bacd207e8620aa7bae9
