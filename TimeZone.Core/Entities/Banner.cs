using TimeZone.Core.Entities.Commons;

namespace TimeZone.Core.Entities;

public class Banner:BaseEntity
{
    public string BannerImage  { get; set; }
    public string Title { get; set; }
    public double Price { get; set; }
}
