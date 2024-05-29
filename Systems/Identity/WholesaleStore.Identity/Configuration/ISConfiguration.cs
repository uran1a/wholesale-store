using Microsoft.AspNetCore.Identity;
using WholesaleStore.Context.Context;
using WholesaleStore.Context.Entities;
using WholesaleStore.Identity.Configuration.IS;
using WholesaleStore.Identity.Configuration.ISp;

namespace WholesaleStore.Identity.Configuration;

public static class ISConfiguration
{
    public static IServiceCollection AddIS(this IServiceCollection services) 
    {
        services
            .AddIdentity<User, IdentityRole<Guid>>(opt =>
            {
                opt.Password.RequiredLength = 0;
                opt.Password.RequireDigit = false;
                opt.Password.RequireLowercase = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            })
            .AddEntityFrameworkStores<MainDbContext>()
            .AddUserManager<UserManager<User>>()
            .AddDefaultTokenProviders()
            ;
        services
            .AddIdentityServer()
            .AddAspNetIdentity<User>()
            .AddInMemoryApiScopes(AppApiScopes.ApiScopes)
            .AddInMemoryClients(AppClients.Clients)
            .AddInMemoryApiResources(AppResources.Resources)
            .AddInMemoryIdentityResources(AppIdentityResources.Resources)
            
            //.AddTestUsers(AppApiTestUsers.ApiUsers)
            ;

        return services;
    }

    public static IApplicationBuilder UseIS(this IApplicationBuilder app)
    {
        app.UseIdentityServer();

        return app;
    }
}
