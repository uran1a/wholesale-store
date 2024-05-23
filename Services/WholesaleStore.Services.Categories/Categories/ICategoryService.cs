using WholesaleStore.Services.Categories.Categories.Models;

namespace WholesaleStore.Services.Categories.Categories;

public interface ICategoryService
{
    Task<IEnumerable<CategoryModel>> GetAll();
}
