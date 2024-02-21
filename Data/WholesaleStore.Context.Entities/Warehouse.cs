using WholesaleStore.Context.Entities.Common;

namespace WholesaleStore.Context.Entities;

public class Warehouse : BaseEntity
{
    public string Address { get; set; }
    public virtual ICollection<Rack> Racks { get; set; }
}
