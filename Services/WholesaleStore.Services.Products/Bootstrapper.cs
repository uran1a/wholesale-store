using Microsoft.Extensions.DependencyInjection;
using WholesaleStore.Services.Products.Products;

namespace WholesaleStore.Services.Products;

public static class Bootstrapper    
{
    public static IServiceCollection AddProductService(this IServiceCollection service)
    {
        return service
            .AddSingleton<IProductService, ProductService>();
    }
}
