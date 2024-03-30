using Microsoft.AspNetCore.Mvc;
using WholesaleStore.Auth.Models;
using WholesaleStore.Auth.Services;

namespace WholesaleStore.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        private readonly IAuthService authService = authService;

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(LoginUser user)
        {
            if (await authService.RegisterUser(user))
                return Ok("Успешно!");
            return BadRequest("Что-то пошло не так!");
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginUser user)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var loginResult = await authService.Login(user);
            if(loginResult.IsLogedIn)
            {
                return Ok(loginResult);
            }
            return Unauthorized();
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken(TokenPair pair)
        {
            var loginResult = await authService.RefreshToken(pair);
            if (loginResult.IsLogedIn)
            {
                return Ok(loginResult);
            }
            return Unauthorized();
        }
    }
}
