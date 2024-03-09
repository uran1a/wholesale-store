using WholesaleStore.Services.Products.Products.Models;

namespace WholesaleStore.Services.Products.Products;

public interface IProductService
{
    Task<IEnumerable<ProductModel>> GetAll();
}
