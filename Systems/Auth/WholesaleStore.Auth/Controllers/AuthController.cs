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

            if(await authService.Login(user))
            {
                var token = authService.GenerateToken(user);
                return Ok(token);
            }
            return BadRequest("Неверный логин или пароль!");
        }
    }
}
