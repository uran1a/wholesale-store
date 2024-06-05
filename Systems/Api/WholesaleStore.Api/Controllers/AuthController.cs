using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WholesaleStore.Services.UserAccount.UserAccount.Models;
using WholesaleStore.Services.UserAccount.UserAccount;
using WholesaleStore.Common.Settings;
using WholesaleStore.Services.Products.Products.Models;
using WholesaleStore.Services.Products.Products;
using System.Data.OleDb;

namespace WholesaleStore.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Auth")]
[Route("api/v{version:apiVersion}/auth")]
public class AuthController(
    IMapper mapper,
    ILogger<AccountsController> logger,
    IUserAccountService userAccountService) : ControllerBase
{
    private readonly IMapper mapper = mapper;
    private readonly ILogger<AccountsController> logger = logger;
    private readonly IUserAccountService userAccountService = userAccountService;

    [HttpPost("")]
    public async Task<UserAccountModel> Register([FromBody] RegisterUserAccountModel request)
    {
        var user = await userAccountService.Create(request);

        return user;
    }

    [HttpPost("profile")]
    public async Task<IActionResult> GetProfile([FromBody] string accessToken)
    {
        var result = await userAccountService.GetProfile(accessToken);
        if (result == null)
            return BadRequest();

        return Ok(result);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUserAccountModel user)
    {
        if (!ModelState.IsValid)
            return BadRequest();

        var userAccount = await userAccountService.Login(user);

        if (userAccount != null)
            return Ok(userAccount);

        return Unauthorized();
    }

    [HttpPut("users/{id:Guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, UpdateUserAccountModel request)
    {
        var result = await userAccountService.Update(id, request);
        if (result != null)
            return Ok(result);

        return BadRequest();
    }
}
