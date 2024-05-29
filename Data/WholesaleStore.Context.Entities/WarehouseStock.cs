using WholesaleStore.Context.Entities.Common;

namespace WholesaleStore.Context.Entities;

public class WarehouseStock : BaseEntity
{
    public int WarehouseId { get; set; }
    public virtual Warehouse Warehouse { get; set; } = default!;
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = default!;
    public int Quentity { get; set; }
}
