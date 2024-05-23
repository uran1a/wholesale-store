using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.Net;
using System.Security.Claims;
using WholesaleStore.Auth.Models;
using WholesaleStore.Auth.Services;
using WholesaleStore.Common.Extensions;
using WholesaleStore.Services.Settings.Settings;
using static System.Net.Mime.MediaTypeNames;

namespace WholesaleStore.Auth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService, JwtSettings settings) : ControllerBase
    {
        private readonly IAuthService authService = authService;
        private readonly JwtSettings settings = settings;

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

            if (loginResult.IsLogedIn)
            {
                Response.Cookies.Append(
                    "refreshToken",
                    loginResult.RefreshToken,
                    new CookieOptions()
                    {
                       HttpOnly = true,
                       Expires = DateTime.UtcNow.AddSeconds(int.Parse(settings.RefreshTokenAge))
                    });

                return Ok(loginResult);
            }
            return Unauthorized();
        }

        [HttpGet("Logout")]
        public async Task<IActionResult> Logout()
        {
            Response.Cookies.Append(
                "refreshToken",
                "",
                new CookieOptions()
                {
                    HttpOnly = true,
                    Expires = DateTime.UtcNow,
                });

            return Ok();
        }

        [HttpGet("Refresh")]
        public async Task<IActionResult> Refresh()
        {
            var refreshToken = Request.Cookies["refreshToken"];
            if (refreshToken != null && refreshToken != "")
            {
                var loginResult = await authService.RefreshTokens(refreshToken);
                if (loginResult.IsLogedIn)
                {
                    Response.Cookies.Append(
                    "refreshToken",
                    loginResult.RefreshToken,
                    new CookieOptions()
                    {
                        HttpOnly = true,
                        Expires = DateTime.UtcNow.AddSeconds(int.Parse(settings.RefreshTokenAge))
                    });

                    return Ok(loginResult);
                }
            }
            return Unauthorized();
        }
    }
}
