namespace src.Models
{
    public class TaskModel
    {
        public TaskModel(string title, string description, TagTypeModel tag)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Tag = tag;
            CreatedAt = DateTime.UtcNow;
        }

        public Guid Id { get; init; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public TagTypeModel Tag { get; set; }
        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
