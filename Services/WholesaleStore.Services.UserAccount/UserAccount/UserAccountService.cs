using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WholesaleStore.Common.Exceptions;
using WholesaleStore.Common.Settings;
using WholesaleStore.Common.Validator;
using WholesaleStore.Context.Context;
using WholesaleStore.Context.Entities;
using WholesaleStore.Services.UserAccount.UserAccount.Models;

namespace WholesaleStore.Services.UserAccount.UserAccount;

public class UserAccountService (
    IDbContextFactory<MainDbContext> dbContextFactory,
    IMapper mapper,
    IModelValidator<UpdateUserAccountModel> updateUserAccountModelValidator,
    IModelValidator<RegisterUserAccountModel> registerUserAccountModelValidator
    ) : IUserAccountService
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory = dbContextFactory;
    private readonly IMapper mapper = mapper;
    private readonly IModelValidator<UpdateUserAccountModel> updateUserAccountModelValidator = updateUserAccountModelValidator;
    private readonly IModelValidator<RegisterUserAccountModel> registerUserAccountModelValidator = registerUserAccountModelValidator;

    public async Task<UserAccountModel> Create(RegisterUserAccountModel model)
    {
        registerUserAccountModelValidator.Check(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        if (await context.Users.AnyAsync(x => x.Email.Equals(model.Email)))
        {
            throw new ProcessException($"User account with email {model.Email} already exist.");
        }

        var user = new User()
        {
            Status = UserStatus.Active,
            Role = UserRole.Client,
            Name = model.Name,
            Password = model.Password,
            Address = model.Address,
            Avatar = model.Avatar,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
        };

        var result = await context.Users.AddAsync(user);

        await context.SaveChangesAsync();

        if (result == null)
            throw new ProcessException($"Creating user account is wrong.");

        return mapper.Map<UserAccountModel>(user);
    }

    public async Task<UserAccountModel?> GetProfile(string accessToken)
    {
        var principal = GetTokenPrincipal(accessToken, "6AD2EFDE-AB2C-4841-A05E-7045C855BA22");

        if (principal?.Identity?.Name is null)
            return null;

        using var context = await dbContextFactory.CreateDbContextAsync();

        var user = await context.Users.FirstOrDefaultAsync(x => x.Email.Equals(principal.Identity.Name));

        return mapper.Map<UserAccountModel>(user);
    }

    public async Task<bool> IsEmpty()
    {
        using var context = await dbContextFactory.CreateDbContextAsync();
        return !(await context.Users.AnyAsync());
    }

    public async Task<UserAccountModel?> Login(LoginUserAccountModel model)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();
        
        var user = await context.Users.FirstOrDefaultAsync(x => x.Email.Equals(model.Email));

        if (user == null)
            return null;

        return mapper.Map<UserAccountModel>(user);
    }

    private ClaimsPrincipal? GetTokenPrincipal(string token, string signature)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signature));
        var validation = new TokenValidationParameters
        {
            IssuerSigningKey = securityKey,
            ValidateLifetime = true,
            ValidateActor = false,
            ValidateIssuer = false,
            ValidateAudience = false
        };

        return new JwtSecurityTokenHandler().ValidateToken(token, validation, out _);
    }

    public async Task<UserAccountModel?> Update(Guid id, UpdateUserAccountModel model)
    {
        await updateUserAccountModelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var user = await context.Users.Where(x => x.Uid == id).FirstOrDefaultAsync();

        if (user == null)
            return null;

        user = mapper.Map(model, user);

        context.Users.Update(user);

        await context.SaveChangesAsync();

        return mapper.Map<UserAccountModel>(user);
    }

    private string GenerateToken(string userName, string signature, int age)
    {
        var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userName),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim("iat", DateTime.UtcNow.ToString(), ClaimValueTypes.Integer64),
            };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signature));
        var signingCred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var securityToken = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.UtcNow.AddDays(age),
            signingCredentials: signingCred);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }
}
