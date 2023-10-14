using TimeZone.Core.Entities.Commons;

namespace TimeZone.Core.Entities;

public class Category:BaseEntity
{
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }

    public Category()
    {
        Products = new List<Product>();
    }
}
