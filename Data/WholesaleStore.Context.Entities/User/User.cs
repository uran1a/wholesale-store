using Microsoft.AspNetCore.Identity;

namespace WholesaleStore.Context.Entities.User;

public class User : IdentityUser<Guid>
{
    public string FullName { get; set; }
    public UserStatus Status { get; set; }

    public static implicit operator Task<object>(User v)
    {
        throw new NotImplementedException();
    }
}
