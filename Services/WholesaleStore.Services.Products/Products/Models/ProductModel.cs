using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;
using WholesaleStore.Context.Context;
using WholesaleStore.Context.Entities;
using WholesaleStore.Services.Categories.Categories.Models;

namespace WholesaleStore.Services.Products.Products.Models;

public class ProductModel
{
    public Guid Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public double Price { get; set; }
    public int Quantity { get; set; } = default!;
    public CategoryModel Category { get; set; } = new CategoryModel();
    public IEnumerable<string> Images { get; set; } = default!;
}

public class ProductModelProfile : Profile
{
    public ProductModelProfile()
    {
        CreateMap<Product, ProductModel>()
            .BeforeMap<ProductModelActions>()
            .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Category, opt => opt.Ignore())
            .ForMember(dest => dest.Images, opt => opt.Ignore())
            .ForMember(dest => dest.Quantity, opt => opt.Ignore())
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