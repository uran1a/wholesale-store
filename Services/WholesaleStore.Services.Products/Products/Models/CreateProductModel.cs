using AutoMapper;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using WholesaleStore.Context.Context;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Services.Products.Products.Models;

public class CreateProductModel
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public double Price { get; set; }
    public int Quantity { get; set; } = default!;
    public Guid CategoryId { get; set; }
    public List<string> Images { get; set; } = new List<string>();
}

public class CreateProductModelProfile : Profile
{
    public CreateProductModelProfile()
    {
        CreateMap<CreateProductModel, Product>()
            .ForMember(dest => dest.CategoryId, opt => opt.Ignore())
            .ForMember(dest => dest.Images, opt => opt.Ignore())
            .AfterMap<CreateModelActions>();
    }

    public class CreateModelActions : IMappingAction<CreateProductModel, Product>
    {
        private readonly IDbContextFactory<MainDbContext> contextFactory;

        public CreateModelActions(IDbContextFactory<MainDbContext> contextFactory)
        {
            this.contextFactory = contextFactory;
        }

        public void Process(CreateProductModel source, Product destination, ResolutionContext context)
        {
            using var db = contextFactory.CreateDbContext();

            var category = db.Categories.FirstOrDefault(x => x.Uid == source.CategoryId);

            destination.CategoryId = category!.Id;
        }
    }
}

public class CreateProductModelValidator : AbstractValidator<CreateProductModel>
{
    public CreateProductModelValidator(IDbContextFactory<MainDbContext> contextFactory)
    {
        RuleFor(x => x.Title)
           .NotEmpty().WithMessage("Title is required.")
           .MaximumLength(200).WithMessage("Title must be less than 200 characters.");

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage("Description is required.")
            .MaximumLength(1000).WithMessage("Description must be less than 1000 characters.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than zero.");

        RuleFor(x => x.Quantity)
            .GreaterThanOrEqualTo(0).WithMessage("Quantity must be zero or greater.");

        RuleFor(x => x.CategoryId)
            .NotEmpty().WithMessage("Category is required")
            .Must((id) =>
            {
                using var context = contextFactory.CreateDbContext();
                return context.Categories.Any(a => a.Uid == id);
            }).WithMessage("Category not found");

        RuleFor(x => x.Images)
           .Must(images => images != null && images.Count == 3)
           .WithMessage("Exactly 3 images are required.")
           .ForEach(image =>
           {
               image.Must(url => Uri.TryCreate(url, UriKind.Absolute, out _))
                    .WithMessage("'{PropertyValue}' is not a valid URL.");
           });
    }
}

