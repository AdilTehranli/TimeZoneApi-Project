namespace TimeZone.Business.Exceptions.Role;

public class RoleCreateFailedException : Exception
{
    public RoleCreateFailedException():base("Samething went error")
    {
    }

    public RoleCreateFailedException(string? message) : base(message)
    {
    }
}
