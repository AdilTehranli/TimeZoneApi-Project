using TimeZone.Core.Entities.Commons;

namespace TimeZone.Core.Entities;

public class Contact:BaseEntity
{
    public string Message { get; set; }
    public string Name { get; set; }
    public string MailAddress { get; set; }
    public string Subject { get; set; }
}
