namespace ProjekatSI.DTO
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
