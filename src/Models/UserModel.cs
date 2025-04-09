using System.Data;

namespace src.Models
{
    public class Responsible
    {
        public Guid Id { get; init; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreatedAT { get; init;  } = DateTime.UtcNow;
    }
}
