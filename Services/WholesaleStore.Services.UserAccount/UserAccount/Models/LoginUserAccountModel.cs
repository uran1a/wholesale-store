using FluentValidation;

namespace WholesaleStore.Services.UserAccount.UserAccount.Models;
public class LoginUserAccountModel
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}

public class LoginUserAccountModelValidator : AbstractValidator<LoginUserAccountModel>
{
    public LoginUserAccountModelValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Password)
           .NotEmpty().WithMessage("Password is required.")
           .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
           .MaximumLength(50).WithMessage("Password can't exceed 50 characters.");
    }
}