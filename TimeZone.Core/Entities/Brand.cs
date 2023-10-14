using TimeZone.Core.Entities.Commons;

namespace TimeZone.Core.Entities;

public class Brand:BaseEntity
{
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }


    public Brand()
    {
        Products = new List<Product>();
    }
}
