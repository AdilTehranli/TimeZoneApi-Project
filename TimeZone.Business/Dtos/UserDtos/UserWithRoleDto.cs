using Microsoft.AspNetCore.Identity;

namespace TimeZone.Business.Dtos.UserDtos;

public class UserWithRoleDto
{
    public AuthorDto User { get; set; }
    public IEnumerable<string> Roles { get; set; }
}
