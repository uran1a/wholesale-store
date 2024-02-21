using WholesaleStore.Context.Entities.Common;

namespace WholesaleStore.Context.Entities;

public class WarehouseProduct : BaseEntity
{
    public int PositionX { get; set; }
    public int PositionY { get; set; }

    public int ProductId { get; set; }
    public virtual Product Product { get; set; }
    public int ShelfId { get; set; }
    public virtual Shelf Shelf { get; set; }
}
