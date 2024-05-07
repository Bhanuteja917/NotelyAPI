using Notely.Models.Entities;

namespace Notely.Services
{
    public interface INotesRepository
    {
        public Task<IEnumerable<Notes>> GetNotesAsync();
        public Task<Notes?> GetNoteAsync(int noteId);
        public Task AddNoteAsync(Notes note);
        public void DeleteNote(Notes note);
        public Task<bool> SaveChangesAsync();
    }
}
