using System.Data;

namespace src.Models
{
    public class UserModel
    {
        public UserModel(string username, string email)
        {
            Id = Guid.NewGuid();
            Username = username;
            Email = email;
            CreatedAT = DateTime.UtcNow;
        }

        public Guid Id { get; init; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAT { get; init;  } = DateTime.UtcNow;
    }
}
