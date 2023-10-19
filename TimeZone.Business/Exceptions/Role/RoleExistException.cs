namespace TimeZone.Business.Exceptions.Role;

public class RoleExistException : Exception
{
    public RoleExistException():base("Role already exist")
    {
    }

    public RoleExistException(string? message) : base(message)
    {
    }
}
