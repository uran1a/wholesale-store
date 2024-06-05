using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WholesaleStore.Context.Context;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Services.UserAccount.UserAccount.Models;

public class RegisterUserAccountModel
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string Avatar { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Address { get; set; } = default!;
}

/*
public class UserModelProfile : Profile
{
    public UserModelProfile()
    {
        CreateMap<User, RegisterUserAccountModel>()
            .BeforeMap<ProductModelActions>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Category, opt => opt.Ignore())
            .ForMember(dest => dest.Images, opt => opt.Ignore())
            .ForMember(dest => dest.Quantity, opt => opt.Ignore())
            ;
    }

    public class MModelActions : IMappingAction<Product, ProductModel>
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public ProductModelActions(IDbContextFactory<MainDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public void Process(Product source, ProductModel destination, ResolutionContext context)
        {
            using var db = contextFactory.CreateDbContext();

            var product = db.Products
                .Include(x => x.Images)
                .Include(x => x.Category)
                .Include(x => x.WarehouseStocks)
                .FirstOrDefault(x => x.Id == source.Id);

            destination.Id = product.Uid;
            destination.Category.Id = product.Category.Uid;
            destination.Category.Name = product.Category.Name;
            destination.Images = product.Images.Select(x => x.Url);
            destination.Quantity = product.WarehouseStocks.Sum(x => x.Quentity);
        }
    }
}
*/
public class RegisterUserAccountModelValidator : AbstractValidator<RegisterUserAccountModel>
{
    public RegisterUserAccountModelValidator()
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
