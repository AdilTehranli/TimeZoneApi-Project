using TimeZone.Core.Entities.Commons;

namespace TimeZone.Core.Entities;

public class Product:BaseEntity
{
    public string ProductImage { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
    public string Description { get; set; }
    public int CategoryId { get; set; }
    public  Category Category { get; set; }
    public int BrandId { get; set; }
    public  Brand Brand { get; set; }
}
