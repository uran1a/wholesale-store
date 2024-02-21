using WholesaleStore.Context.Entities.Common;

namespace WholesaleStore.Context.Entities;

public class Product : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
    public double Weight { get; set; }
    public double Price { get; set; }

    public virtual Box Box { get; set; }
    public virtual ICollection<Category> Categories { get; set; }
    public virtual ICollection<WarehouseProduct> WarehouseProducts { get; set; }
}
