using WholesaleStore.Context.Entities.Common;

namespace WholesaleStore.Context.Entities;

public class Shelf : BaseEntity
{
    public int Level { get; set; }
    public double Height { get; set; }
    public double LoadCapacity { get; set; }

    public virtual ICollection<WarehouseProduct> WarehouseProducts { get; set; }
}
