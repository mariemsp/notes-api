using Microsoft.EntityFrameworkCore;
using NotesApi.Models;

namespace NotesApi
{
    public class NotesDBContext : DbContext
    {
        public NotesDBContext(DbContextOptions<NotesDBContext> options) : base(options)
        { }

        public DbSet<Note> Notes { get; set; }
    }
}