using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WholesaleStore.Services.UserAccount.UserAccount;
using WholesaleStore.Services.UserAccount.UserAccount.Models;

namespace WholesaleStore.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[ApiExplorerSettings(GroupName = "Product")]
[Route("v{version:apiVersion}/[controller]")]
public class AccountsController(
    IMapper mapper,
    ILogger<AccountsController> logger,
    IUserAccountService userAccountService) : ControllerBase
{
    private readonly IMapper mapper = mapper;
    private readonly ILogger<AccountsController> logger = logger;
    private readonly IUserAccountService userAccountService = userAccountService;

    [HttpPost("")]
    public async Task<UserAccountModel> Register([FromQuery] RegisterUserAccountModel request)
    {
        var user = await userAccountService.Create(request);

        return user;
    }
}
