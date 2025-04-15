using src.Models;

namespace src.Dto
{
    public class TaskDTO
    {
        public TaskDTO(string title, string description, TagTypeModel tag, Guid idUser)
        {
            Title = title;
            Description = description;
            Tag = tag;
            IdUser = idUser;
        }

        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public TagTypeModel Tag { get; set; }

        public Guid IdUser { get; set; }
    }
}
