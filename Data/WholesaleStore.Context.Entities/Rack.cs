
using WholesaleStore.Context.Entities.Common;

namespace WholesaleStore.Context.Entities;

public class Rack : BaseEntity
{
    public double Length { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public int PositionX { get; set; }
    public int PositionY { get; set; }

    public int WarehouseId { get; set; }
    public virtual Warehouse Warehouse { get; set; }
    public virtual ICollection<Shelf> Shelves { get; set; }
}
