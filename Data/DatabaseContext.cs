<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;

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
=======
﻿using Microsoft.EntityFrameworkCore;

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
>>>>>>> 2841b6ef995917dae6568bacd207e8620aa7bae9
