using Microsoft.EntityFrameworkCore;
using ProjekatSI.Data;
using ProjekatSI.Interface;
using System.Net;

namespace ProjekatSI.Service
{
    public class AnswerService : IAnswerIntefrace
    {
        public DatabaseContext _databaseContext;

        public AnswerService(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        public async Task<List<QuestionAnswer>> GetAllAnswersAsync()
        {
           return await  _databaseContext.Answers.Include( answer => answer.User).Include( answer => answer.Question).ToListAsync();
        }
        public async Task<List<QuestionAnswer>> GetAllAnswersByQuestion(int QuestionId)
        {
            return await _databaseContext.Answers.Where( answer => answer.QuestionId == QuestionId).Include( answer => answer.User).Include( answer => answer.Question).ToListAsync();
        }
        public async Task CreateAnswer(QuestionAnswer answer)
        {
            _databaseContext.Answers.Add(answer);
            await _databaseContext.SaveChangesAsync();
        }
        public async Task DeleteAnswer(QuestionAnswer answer)
        {
            _databaseContext.Answers.Remove(answer);
            await _databaseContext.SaveChangesAsync();
        }
        public async Task UpdateAnswer(QuestionAnswer answer)
        {
            _databaseContext.Answers.Update(answer);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<QuestionAnswer?> GetAnswerById(int id)
        {
            return await _databaseContext.Answers.Where( answer => answer.Id == id).FirstOrDefaultAsync();
        }
    }
}
