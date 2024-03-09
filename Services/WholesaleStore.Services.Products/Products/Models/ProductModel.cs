using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WholesaleStore.Context.Context;
using WholesaleStore.Context.Entities;

namespace WholesaleStore.Services.Products.Products.Models;

public class ProductModel
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public IEnumerable<string> Categories { get; set; }
}

public class ProductModelProfile : Profile
{
    public ProductModelProfile()
    {
        CreateMap<Product, ProductModel>()
            .BeforeMap<ProductModelActions>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Categories, opt => opt.Ignore())
            ;
    }

    public class ProductModelActions : IMappingAction<Product, ProductModel>
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
                .FirstOrDefault(x => x.Id == source.Id);

            destination.Id = product.Uid;
            destination.Categories = product.Categories.Select(x => x.Title);
        }
    }
}