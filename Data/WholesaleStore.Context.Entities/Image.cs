using WholesaleStore.Context.Entities.Common;

namespace WholesaleStore.Context.Entities;

public class Image : BaseEntity
{
    public string Url { get; set; } = default!;
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = default!;
}
