using Microsoft.AspNetCore.Identity;

namespace TimeZone.Core.Entities;
    
public class AppUser:IdentityUser
{
    public string Name { get; set; }
    public string Surname { get; set; }
}
