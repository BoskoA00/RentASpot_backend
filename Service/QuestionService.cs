using Microsoft.EntityFrameworkCore;
using ProjekatSI.Data;
using ProjekatSI.Interface;

namespace ProjekatSI.Service
{
    public class QuestionService : IQuestionInterface
    {
        public DatabaseContext _databaseContext;

        public QuestionService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task CreateQuestion(Question question)
        {
            _databaseContext.Questions.Add(question);   
            await _databaseContext.SaveChangesAsync();
        }

        public async Task DeleteQuestion(Question question)
        {
            var answers = await _databaseContext.Answers.Where( x => x.QuestionId == question.Id).ToListAsync();
            _databaseContext.Answers.RemoveRange(answers);
         
            _databaseContext.Questions.Remove(question);
            await _databaseContext.SaveChangesAsync();

        }

        public async Task<List<Question>> GetAllQuestionsAsync()
        {
            return await _databaseContext.Questions.Include( question => question.User).Include( question => question.Answers).ToListAsync();
        }

        public async Task<Question?> GetQuestionById(int id)
        {
            return await _databaseContext.Questions.Include( question => question.User).Where( question => question.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Question>> GetQuestionsByUserId(int UserId)
        {
            return  await _databaseContext.Questions.Where( question => question.UserId == UserId).ToListAsync();
        }


        public async Task UpdateQuestion(Question question)
        {
            _databaseContext.Questions.Update(question);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
