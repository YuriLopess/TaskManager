namespace src.Dto
{
    public class UserDTO
    {
        public UserDTO(string username, string email)
        {
            Username = username;
            Email = email;
        }

        public string Username { get; set; }
        public string Email { get; set; }
    }
}
