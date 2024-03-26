using WholesaleStore.Auth.Models;

namespace WholesaleStore.Auth.Services
{
    public interface IAuthService
    {
        string GenerateToken(LoginUser user);
        Task<bool> Login(LoginUser user);
        Task<bool> RegisterUser(LoginUser user);
    }
}
