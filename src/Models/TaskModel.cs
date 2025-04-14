namespace src.Models
{
    public class TaskModel
    {
        public TaskModel(string title, string description, TagTypeModel tag, Guid idUser)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            Tag = tag;
            CreatedAt = DateTime.UtcNow;
            IdUser = idUser;
        }

        public Guid Id { get; init; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public TagTypeModel Tag { get; set; }

        public Guid IdUser { get; set; }

        public UserModel User { get; set; }

        public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
    }
}
