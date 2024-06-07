using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WholesaleStore.Context.Context;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Services.Categories.Categories.Models;

public class CreateCategoryModel
{
    public string Name { get; set; } = default!;
    public string Image { get; set; } = default!;
}

public class CreateCategoryModelProfile : Profile
{
    public CreateCategoryModelProfile()
    {
        CreateMap<CreateCategoryModel, Category>();
    }
}

public class CreateCategoryModelValidator : AbstractValidator<CreateCategoryModel>
{
    public CreateCategoryModelValidator(IDbContextFactory<MainDbContext> contextFactory)
    {
        RuleFor(x => x.Name)
           .NotEmpty().WithMessage("Title is required.")
           .MaximumLength(200).WithMessage("Title must be less than 200 characters.");

        RuleFor(x => x.Image)
           .Must(image => image != null)
            .WithMessage("Image is required.")
           .Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
            .WithMessage("'{PropertyValue}' is not a valid URL.");
    }
}
