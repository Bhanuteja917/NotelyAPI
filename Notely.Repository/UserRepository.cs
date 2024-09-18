using Microsoft.EntityFrameworkCore;
using Notely.Repository.Entities;
using Notely.Repository.DbContexts;

namespace Notely.Repository
{
    public class UserRepository(NotesDbContext notesDbContext) : IUserRepository
    {
        private readonly NotesDbContext _notesDbContext = notesDbContext;
        public async Task CreateUserAsync(User user)
        {
             await _notesDbContext.Users.AddAsync(user);    
        }

        public async Task<User?> GetUserAsync(string userName)
        {
            return await _notesDbContext.Users.Where(user => user.Username == userName).FirstOrDefaultAsync();
        }

        public async Task<bool> UserExistsAsync(string userName)
        {
            var user = await GetUserAsync(userName);
            return user != null; 
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _notesDbContext.SaveChangesAsync() >= 0);
        }
    }
}
