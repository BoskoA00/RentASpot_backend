namespace ProjekatSI.DTO
{
    public class UserResponseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public string ImageName { get; set; }
        public List<OglasResponseExtraDTO> Oglasi { get; set; }

    }
}
