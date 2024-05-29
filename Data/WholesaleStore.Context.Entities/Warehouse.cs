using WholesaleStore.Context.Entities.Common;

namespace WholesaleStore.Context.Entities;

public class Warehouse : BaseEntity
{
    public string Location { get; set; } = default!;
    public virtual ICollection<WarehouseStock> WarehouseStocks { get; set; } = default!;
}
