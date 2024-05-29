using WholesaleStore.Context.Entities.Common;

namespace WholesaleStore.Context.Entities;

public class Order : BaseEntity
{
    public int UserId { get; set; }
    public virtual User User { get; set; } = default!;
    public DateTime OrderDate { get; set; }
    public double TotalAmount { get; set; }
    public OrderStatus Status { get; set; }
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = default!;
}
