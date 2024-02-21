using System.ComponentModel.DataAnnotations;
using WholesaleStore.Context.Entities.Common;

namespace WholesaleStore.Context.Entities;

public class Box : BaseEntity
{
    [Key]
    public int Id { get; set; }
    public virtual Product Product { get; set; }
    public double Length { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
}
