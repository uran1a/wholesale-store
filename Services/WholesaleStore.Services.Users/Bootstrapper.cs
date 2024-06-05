using Microsoft.Extensions.DependencyInjection;
using WholesaleStore.Services.Users.Users;

namespace WholesaleStore.Services.Users;

public static class Bootstrapper
{
    public static IServiceCollection AddUserService(this IServiceCollection services)
    {
        return services
            .AddSingleton<IUserService, UserService>();
    }
}
