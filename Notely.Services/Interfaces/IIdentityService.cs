using Notely.Repository.Entities;
using Notely.Models.Models;

namespace Notely.Services
{
    public interface IIdentityService
    {
        Task<User> Login(UserLoginDto userLoginDto);
        Task<User?> Register(UserCreationDto userCreationDto);
    }
}
