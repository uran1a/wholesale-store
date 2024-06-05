using AutoMapper;
using FluentValidation;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Services.UserAccount.UserAccount.Models;

public class UpdateUserAccountModel
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Avatar { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Address { get; set; } = default!;
}

public class UpdateUserAccountModelProfile : Profile
{
    public UpdateUserAccountModelProfile()
    {
        CreateMap<UpdateUserAccountModel, User>()
             .ForMember(dest => dest.Id, opt => opt.Ignore())
             .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
             .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
             .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
             .ForMember(dest => dest.Avatar, opt => opt.MapFrom(src => src.Avatar))
             .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
             .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
             ;
    }
}

public class UpdateUserAccountModelValidator : AbstractValidator<UpdateUserAccountModel>
{
    public UpdateUserAccountModelValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");

        RuleFor(x => x.Password)
           .NotEmpty().WithMessage("Password is required.")
           .MinimumLength(6).WithMessage("Password must be at least 6 characters long.")
           .MaximumLength(50).WithMessage("Password can't exceed 50 characters.");

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required.")
            .MaximumLength(50).WithMessage("Name can't exceed 50 characters.");

        RuleFor(x => x.Avatar)
            .NotEmpty().WithMessage("Avatar is required.")
            .Must(isValidUrl).WithMessage("Avatar must be a valid URL.");

        RuleFor(x => x.PhoneNumber)
            .NotEmpty().WithMessage("Phone number is required.")
            .Matches(@"^\+?\d{10,15}$").WithMessage("Invalid phone number format.");

        RuleFor(x => x.Address)
            .NotEmpty().WithMessage("Address is required.")
            .MaximumLength(100).WithMessage("Address cannot exceed 100 characters.");
    }

    private bool isValidUrl(string url)
    {
        return Uri.TryCreate(url, UriKind.Absolute, out _);
    }
}
