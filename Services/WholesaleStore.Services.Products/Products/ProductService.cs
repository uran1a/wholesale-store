using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using WholesaleStore.Common.Validator;
using WholesaleStore.Context.Context;
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
            .Include(x => x.Categories)
            .ToListAsync();

        var result = mapper.Map <IEnumerable<ProductModel>>(products);

        return result;
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
