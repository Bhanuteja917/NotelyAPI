using AutoMapper;
using Notely.Repository.Entities;
using Notely.Models.Models;
using Notely.Repository;

namespace Notely.Services
{
    public class IdentityService(IUserRepository userRepository, IMapper mapper) : IIdentityService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly IMapper _mapper = mapper;
        public Task<User> Login(UserLoginDto userLoginDto)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> Register(UserCreationDto userCreationDto)
        {
            if(!await _userRepository.UserExistsAsync(userCreationDto.UserName))
            {
                var userToCreate = _mapper.Map<User>(userCreationDto);
                await _userRepository.CreateUserAsync(userToCreate);
            }
            return default;
        }
    }
}
