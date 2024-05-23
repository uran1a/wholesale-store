namespace WholesaleStore.Auth.Models
{
    public class LoginResponse
    {
        public bool IsLogedIn { get; set; } = false;
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
