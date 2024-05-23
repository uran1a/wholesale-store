using WholesaleStore.Auth.Models;

namespace WholesaleStore.Auth.Services
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginUser user);
        Task<bool> RegisterUser(LoginUser user);
        Task<LoginResponse> RefreshTokens(string refreshToken);
    }
}
