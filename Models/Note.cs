namespace NotesApi.Models
{
    public class Note
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public Note() { }

        public Note(long id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
    }
}