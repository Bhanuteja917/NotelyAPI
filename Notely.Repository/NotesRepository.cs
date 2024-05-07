using Notely.Repository.DbContexts;
using Notely.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace Notely.Services
{
    public class NotesRepository(NotesDbContext notesDbContext) : INotesRepository
    {
        private readonly NotesDbContext _notesDbContext = notesDbContext ?? throw new ArgumentNullException(nameof(notesDbContext));
        public async Task<IEnumerable<Notes>> GetNotesAsync()
        {
            return await _notesDbContext.Notes.ToListAsync();
        }

        public async Task<Notes?> GetNoteAsync(int noteId)
        {
            return await _notesDbContext.Notes.Where(n => n.Id == noteId).FirstOrDefaultAsync();
        }

        public async Task AddNoteAsync(Notes note)
        {
            await _notesDbContext.Notes.AddAsync(note);
        }

        public void DeleteNote(Notes note)
        {
            _notesDbContext.Notes.Remove(note);
        }

        public async Task<bool> SaveChangesAsync()
        {
           return (await _notesDbContext.SaveChangesAsync() >= 0);
        }
    }
}
