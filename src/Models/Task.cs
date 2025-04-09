namespace src.Models
{
    public class Task
    {
        public Guid Id { get; init; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public List<TagType> Tag { get; set; }
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
