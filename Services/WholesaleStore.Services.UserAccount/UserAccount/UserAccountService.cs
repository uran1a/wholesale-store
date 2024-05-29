using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using WholesaleStore.Common.Exceptions;
using WholesaleStore.Common.Validator;
using WholesaleStore.Context.Entities;
using WholesaleStore.Services.UserAccount.UserAccount.Models;

namespace WholesaleStore.Services.UserAccount.UserAccount;

public class UserAccountService : IUserAccountService
{
    private readonly IMapper mapper;
    private readonly UserManager<User> userManager;
    private readonly IModelValidator<RegisterUserAccountModel> registerUserAccountModelValidator;

    public UserAccountService(
        IMapper mapper, 
        UserManager<User> userManager, 
        IModelValidator<RegisterUserAccountModel> registerUserAccountModelValidator)
    {
        this.mapper = mapper;
        this.userManager = userManager;
        this.registerUserAccountModelValidator = registerUserAccountModelValidator;
    }
    public async Task<UserAccountModel> Create(RegisterUserAccountModel model)
    {
        /*
        registerUserAccountModelValidator.Check(model);

        var user = await userManager.FindByEmailAsync(model.Email);
        if (user != null)
            throw new ProcessException($"User account with email {model.Email} already exist.");

        user = new User()
        {
            Status = UserStatus.Active,
            FullName = model.Name,
            UserName = model.Email,  
            Email = model.Email,
            EmailConfirmed = true,
            PhoneNumber = null,
            PhoneNumberConfirmed = false

        };

        var result = await userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
            throw new ProcessException($"Creating user account is wrong. {string.Join(", ", result.Errors.Select(s => s.Description))}");

        */
        return mapper.Map<UserAccountModel>(new User());
    }

    //public async Task<UserAccountModel> SignIn

    public async Task<bool> IsEmpty()
    {
        return !(await userManager.Users.AnyAsync());
    }
}
