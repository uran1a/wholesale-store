using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WholesaleStore.Common.Validator;
using WholesaleStore.Context.Context;
using WholesaleStore.Context.Entities;
using WholesaleStore.Services.Products.Products.Models;

namespace WholesaleStore.Services.Products.Products;

public class ProductService(
    IDbContextFactory<MainDbContext> dbContextFactory,
    IMapper mapper,
    IModelValidator<UpdateModel> updateModelValidator
    ) : IProductService
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory = dbContextFactory;
    private readonly IMapper mapper = mapper;
    private readonly IModelValidator<UpdateModel> updateModelValidator = updateModelValidator;

    public async Task<IEnumerable<ProductModel>> GetAll()
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var products = await context.Products
            .Include(x => x.Category)
            .ToListAsync();

        var result = mapper.Map<IEnumerable<ProductModel>>(products);

        return result;
    }

    public async Task<ProductModel> GetById(Guid id)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var product = await context.Products
            .Include(x => x.Category)
            .FirstOrDefaultAsync(x => x.Uid.Equals(id));

        var result = mapper.Map<ProductModel>(product);

        return result;
    }

    public async Task<IEnumerable<ProductModel>> Search(string title, double priceMin, double priceMax, string categoryUId)
    {
        using var context = await dbContextFactory.CreateDbContextAsync();
        var products = await context.Products
            .Include(x => x.Category)
            .ToListAsync();

        if (categoryUId != string.Empty)
        {
            products = products.Where(x => x.Category.Uid == new Guid(categoryUId)).ToList();
        }

        if (title != string.Empty)
        {
            products = products.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToList();
        }

        if (priceMin > 0)
        {
            products = products.Where(x => x.Price >= priceMin).ToList();
        }

        if (priceMax > 0)
        {
            products = products.Where(x => x.Price < priceMax).ToList();
        }

        return mapper.Map<IEnumerable<ProductModel>>(products);
    }

    public async Task Update(Guid id, UpdateModel model)
    {
        await updateModelValidator.CheckAsync(model);

        using var context = await dbContextFactory.CreateDbContextAsync();

        var book = await context.Products.Where(x => x.Uid == id).FirstOrDefaultAsync();

        book = mapper.Map(model, book);

        context.Products.Update(book);

        await context.SaveChangesAsync();
    }
}
