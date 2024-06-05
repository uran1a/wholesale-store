namespace WholesaleStore.Services.UserAccount.UserAccount.Models;

public class LoginUserAccountResponse
{
    public bool IsLogedIn { get; set; } = false;
    public string AccessToken { get; set; } = default!;
}
