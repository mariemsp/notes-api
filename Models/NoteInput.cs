using System.ComponentModel.DataAnnotations;

namespace NotesApi.Models
{
    public class NoteInput
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}