using WholesaleStore.Context.Entities.Common;

namespace WholesaleStore.Context.Entities;

public class Category : BaseEntity
{
    public string Name { get; set; } = default!;
    public string Image { get; set; } = default!;
    public virtual ICollection<Product> Products { get; set; } = default!;
}
