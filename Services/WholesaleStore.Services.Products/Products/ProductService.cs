using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WholesaleStore.Context.Context;
using WholesaleStore.Services.Products.Products.Models;

namespace WholesaleStore.Services.Products.Products;

public class ProductService : IProductService
{
    private readonly IDbContextFactory<MainDbContext> dbContextFactory;
    private readonly IMapper mapper;

    public ProductService(IDbContextFactory<MainDbContext> dbContextFactory,
        IMapper mapper
        )
    {
        this.dbContextFactory = dbContextFactory;
        this.mapper = mapper;
    }
    public async Task<IEnumerable<ProductModel>> GetAll()
    {
        using var context = await dbContextFactory.CreateDbContextAsync();

        var products = await context.Products
            .Include(x => x.Categories)
            .ToListAsync();

        var result = mapper.Map <IEnumerable<ProductModel>>(products);

        return result;
    }
}
