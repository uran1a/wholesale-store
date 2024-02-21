using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WholesaleStore.Context.Entities.Common;

namespace WholesaleStore.Context.Entities;

public class Category : BaseEntity
{
    public string Title { get; set; }
    public virtual ICollection<Product> Products { get; set; }
}
