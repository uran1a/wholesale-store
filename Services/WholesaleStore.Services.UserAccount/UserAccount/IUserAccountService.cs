using WholesaleStore.Services.UserAccount.UserAccount.Models;

namespace WholesaleStore.Services.UserAccount.UserAccount;

public interface IUserAccountService
{
    Task<UserAccountModel> Create(RegisterUserAccountModel model);
    Task<UserAccountModel?> GetProfile(string accessToken);
    Task<bool> IsEmpty();

    Task<UserAccountModel?> Login(LoginUserAccountModel model);

    Task<UserAccountModel?> Update(Guid id, UpdateUserAccountModel model);
}