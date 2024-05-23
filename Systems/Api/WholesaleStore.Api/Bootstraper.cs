using WholesaleStore.Services.Settings;
using WholesaleStore.Services.Logger;
using WholesaleStore.Services.Products;
using WholesaleStore.Services.UserAccount;
using WholesaleStore.Services.Categories;

namespace WholesaleStore.Api;

public static class Bootstraper
{
    public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration = null)
    {
        services
            .AddMainSettings()
            .AddSwaggerSettings()
            .AddLoggerSettings()
            .AddIdentitySettings()
            .AddAppLogger() 
            .AddProductService()   
            .AddCategoryService()
            //.AddUserAccountService()
            ;

        return services;
    }
}









