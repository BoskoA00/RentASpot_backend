<<<<<<< HEAD
﻿using ProjekatSI.DTO;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjekatSI.Data
{
    public class QuestionAnswer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User  User { get; set; }
        [ForeignKey(nameof(Question))]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
=======
﻿using ProjekatSI.DTO;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjekatSI.Data
{
    public class QuestionAnswer
    {
        public int Id { get; set; }
        public string Content { get; set; }
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }
        public User  User { get; set; }
        [ForeignKey(nameof(Question))]
        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
>>>>>>> 2841b6ef995917dae6568bacd207e8620aa7bae9
