namespace src.Dto
{
    public class UserDTO
    {
        public UserDTO(string username, string email)
        {
            Id = Guid.NewGuid();
            Username = username;
            Email = email;
        }

        public Guid Id { get; init; }
        public string Username { get; set; }
        public string Email { get; set; }
    }
}
