using Microsoft.EntityFrameworkCore;

namespace ProjekatSI.Data
{
    public class DatabaseContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Oglas> Oglasi { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<QuestionAnswer> Answers { get; set; }
        public DatabaseContext(DbContextOptions options):base(options)
        {
            
        }
    }
}
