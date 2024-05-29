using WholesaleStore.Context.Entities.Common;

namespace WholesaleStore.Context.Entities;

public class User : BaseEntity
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string Name { get; set; } = default!;
    public UserStatus Status { get; set; } = default!;
    public UserRole Role { get; set; } = default!;
    public string Avatar { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public string Address { get; set; } = default!;
    public virtual ICollection<Order> Orders { get; set; } = default!;
}
