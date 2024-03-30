namespace WholesaleStore.Auth.Models
{
    public class TokenPair
    {
        public string JwtToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
