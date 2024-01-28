using System.ComponentModel.DataAnnotations.Schema;

namespace ProjekatSI.Data
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public string ImageName { get; set; }
        public List<Question> Questions { get; set; }
        public List<QuestionAnswer> questionAnswers { get; set; }
        public List<Oglas> Oglasi { get; set; }
    }
}
