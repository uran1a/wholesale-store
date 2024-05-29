using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WholesaleStore.Context.Context;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Services.Categories.Categories.Models;

public class CategoryModel
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string Image { get; set; } = default!;
}

public class CategoryModelProfile : Profile
{
    public CategoryModelProfile()
    {
        CreateMap<Category, CategoryModel>()
            .BeforeMap<CategoryModelActions>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            ;
    }
}

public class CategoryModelActions : IMappingAction<Category, CategoryModel>
{
    private readonly IDbContextFactory<MainDbContext> contextFactory;

    public CategoryModelActions(IDbContextFactory<MainDbContext> contextFactory)
    {
        this.contextFactory = contextFactory;
    }

    public void Process(Category source, CategoryModel dest, ResolutionContext context)
    {
        using var db = contextFactory.CreateDbContext();

        var category = db.Categories
            .FirstOrDefault(x => x.Id == source.Id);

        dest.Id = category.Uid;
    }
}
