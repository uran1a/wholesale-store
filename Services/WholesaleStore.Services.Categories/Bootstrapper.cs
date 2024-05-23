using Microsoft.Extensions.DependencyInjection;
using WholesaleStore.Services.Categories.Categories;

namespace WholesaleStore.Services.Categories;

public static class Bootstrapper
{
    public static IServiceCollection AddCategoryService(this IServiceCollection service)
    {
        return service
            .AddSingleton<ICategoryService, CategoryService>();
    }
}
