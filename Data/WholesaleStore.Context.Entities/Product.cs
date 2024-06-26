﻿using WholesaleStore.Context.Entities.Common;

namespace WholesaleStore.Context.Entities;

public class Product : BaseEntity
{
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public double Price { get; set; } = default!;
    public int CategoryId { get; set; }
    public virtual Category Category { get; set; } = default!;
    public virtual ICollection<ProductImage> Images { get; set; } = default!;
    public virtual ICollection<WarehouseStock> WarehouseStocks { get; set; } = default!;
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = default!;
}