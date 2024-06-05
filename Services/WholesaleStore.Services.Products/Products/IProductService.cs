using WholesaleStore.Context.Entities;
using WholesaleStore.Services.Products.Products.Models;

namespace WholesaleStore.Services.Products.Products;

public interface IProductService
{
    Task<IEnumerable<ProductModel>> GetAll();
    Task<ProductModel> GetById(Guid id);
    Task<IEnumerable<ProductModel>> Search(string title, double priceMin, double priceMax, string categoryUId);
    Task Update(Guid id, UpdateModel model);
}
