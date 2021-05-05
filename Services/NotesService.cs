using System.Collections.Generic;
using NotesApi.Models;

namespace NotesApi.Services
{
    public class NotesService
    {
        private readonly List<Note> _storage;
        private long _index;

        public NotesService()
        {
            Note note1 = new Note();
            note1.Id = 1;
            note1.Title = "A Cocinar";
            note1.Description = "Uff! Todos los dias!";
            Note note2 = new Note
            {
                Id = 2,
                Title = "A Comer",
                Description = "Con hambre todo el dia"
            };
            var note3 = new Note
            {
                Id = 3,
                Title = "A Limpiar",
                Description = "De nuevo?"
            };
            var note4 = new Note(4, "A lavar", "Como se ensucia ropa en esta casa");
            var note5 = new Note
            {
                Id = 5,
                Title = "Otra mas",
                Description = "Bueno que mas da"
            };
            _storage = new List<Note> { note1, note2, note3, note4, note5 };
            _index = 6;
        }

        public List<Note> GetAllNotes()
        {
            return _storage;
        }

        public Note AddNote(NoteInput noteInput)
        {
            var note = new Note
            {
                Id = _index++,
                Title = noteInput.Title,
                Description = noteInput.Description
            };
            _storage.Add(note);
            return note;
        }

        public void DeleteNote(long id)
        {
            Note note = GetNote(id);
            _storage.Remove(note);
        }

        public Note GetNote(long id)
        {
            var noteFound = _storage.Find(note =>
            {
                return note.Id == id;
            });
            if (noteFound == null)
            {
                throw new System.Exception("Not Found");
            }
            return noteFound;
        }
    }
}