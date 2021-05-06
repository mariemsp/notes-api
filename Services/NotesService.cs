using System.Collections.Generic;
using System.Linq;
using NotesApi.Models;

namespace NotesApi.Services
{
    public class NotesService
    {
        private readonly NotesDBContext _context;

        public NotesService(NotesDBContext context)
        {
            _context = context;
        }

        public List<Note> GetAllNotes()
        {
            return _context.Notes.ToList();
        }

        public Note AddNote(NoteInput noteInput)
        {
            var note = new Note
            {
                Title = noteInput.Title,
                Description = noteInput.Description
            };
            _context.Notes.Add(note);
            _context.SaveChanges();
            return note;
        }

        public void DeleteNote(long id)
        {
            Note note = GetNote(id);
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }

        public Note GetNote(long id)
        {
            var noteFound = _context.Notes.Find(id);
            if (noteFound == null)
            {
                throw new System.Exception("Not Found");
            }
            return noteFound;
        }

        public Note UpdateNote(long id, NoteInput noteUpdate)
        {
            var note = GetNote(id);
            note.Title = noteUpdate.Title;
            note.Description = noteUpdate.Description;
            _context.Notes.Update(note);
            _context.SaveChanges();
            return note;
        }
    }
}