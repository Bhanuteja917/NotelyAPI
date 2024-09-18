using Notely.Repository.Entities;

namespace Notely.Repository
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(string userName);
        Task CreateUserAsync(User user);
        Task<bool> UserExistsAsync(string userName);
        Task<bool> SaveChangesAsync();
    }
}