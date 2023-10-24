using TimeZone.Core.Entities.Commons;

namespace TimeZone.Core.Entities;

public class About : BaseEntity
{
    public string Title { get; set; }
    public string Description { get; set; }
}
