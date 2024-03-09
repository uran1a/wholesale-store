using Microsoft.Extensions.DependencyInjection;
using WholesaleStore.Services.UserAccount.UserAccount;

namespace WholesaleStore.Services.UserAccount
{
    public static class Bootstrapper 
    {
        public static IServiceCollection AddUserAccountService(this IServiceCollection services)
        {
            services.AddScoped<IUserAccountService, UserAccountService>();

            return services;
        }
    }
}
