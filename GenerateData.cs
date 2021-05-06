using NotesApi.Models;

namespace NotesApi
{
    public class GenerateData
    {
        public static void Initialize(NotesDBContext context)
        {
            Note note1 = new Note();
            note1.Title = "A Cocinar";
            note1.Description = "Uff! Todos los dias!";
            Note note2 = new Note
            {
                Title = "A Comer",
                Description = "Con hambre todo el dia"
            };
            var note3 = new Note
            {
                Title = "A Limpiar",
                Description = "De nuevo?"
            };
            var note4 = new Note("A lavar", "Como se ensucia ropa en esta casa");
            var note5 = new Note
            {
                Title = "Otra mas",
                Description = "Bueno que mas da"
            };
            context.Notes.AddRange(note1, note2, note3, note4, note5);
            context.SaveChanges();
        }
    }
}