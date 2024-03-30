using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace WholesaleStore.Auth.Configuration
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Ура ура!";
        }

        [HttpGet("AuthorizedTest")]
        [Authorize]
        public IActionResult AuthorizedTest()
        {
            var authorizationHeader = this.HttpContext.Request.Headers["Authorization"].FirstOrDefault();

            string jwtTokenString = authorizationHeader.Replace("Bearer ", "");

            var jwt = new JwtSecurityToken(jwtTokenString);

            var response = $"Authenticated!{Environment.NewLine}";

            response += $"{Environment.NewLine}Exp Time: {jwt.ValidTo.ToLongTimeString()}, Time: {DateTime.UtcNow.ToLongTimeString()}";

            return Ok(response);
        }
    }
}
