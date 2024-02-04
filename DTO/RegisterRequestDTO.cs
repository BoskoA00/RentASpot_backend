<<<<<<< HEAD
﻿namespace ProjekatSI.DTO
{
    public class RegisterRequestDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? ImageName { get; set; } = "NoImage.png";
        public IFormFile? Image { get; set; } = null;
        public int Role { get; set; } = 0;

    }
}
=======
﻿namespace ProjekatSI.DTO
{
    public class RegisterRequestDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? ImageName { get; set; } = "NoImage.png";
        public IFormFile? Image { get; set; } = null;
        public int Role { get; set; } = 0;

    }
}
>>>>>>> 2841b6ef995917dae6568bacd207e8620aa7bae9
