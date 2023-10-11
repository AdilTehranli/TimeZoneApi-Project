using TimeZone.Core.Entities.Commons;

namespace TimeZone.Core.Entities;

public class Product:BaseEntity
{
    public string ProductImage { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public int CategoryId { get; set; }
    public int BrandId { get; set; }
}
