using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Notely.Models.Dto;
using Notely.Repository;
using Notely.Services;

namespace Notely.API.Controllers
{
    [Route("api/identity/account")]
    [ApiController]
    public class IdentityController(IIdentityService identityService) : ControllerBase
    {
        private readonly IIdentityService _identityService = identityService;

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserLoginDto userLoginDto)
        {
            return Ok(await _identityService.Login(userLoginDto));
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserCreationDto userCreationDto)
        {
            return Ok(await _identityService.Register(userCreationDto));

        }
    }
}
