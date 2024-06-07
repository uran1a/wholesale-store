using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WholesaleStore.Common.Validator;
using WholesaleStore.Context.Context;
using WholesaleStore.Context.Entities;
using WholesaleStore.Services.Categories.Categories.Models;

namespace WholesaleStore.Services.Categories.Categories;

public class CategoryService(
        IDbContextFactory<MainDbContext> dbContextFactory,
        IMapper mapper,
        IModelValidator<CreateCategoryModel> createCategoryModelValidator
    ) : ICategoryService
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory = dbContextFactory;
    private readonly IMapper mapper = mapper;
    private readonly IModelValidator<CreateCategoryModel> createCategoryModelValidator = createCategoryModelValidator;

    public async Task<IEnumerable<CategoryModel>> GetAll()
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var categories = await context.Categories.ToListAsync();

        var result = mapper.Map<IEnumerable<CategoryModel>>(categories);

        return result;
    }

    public async Task<CategoryModel> Create(CreateCategoryModel model)
    {
        await createCategoryModelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var category = mapper.Map<Category>(model);

        await context.Categories.AddAsync(category);

        await context.SaveChangesAsync();

        return mapper.Map<CategoryModel>(category);
    }
}
