namespace TimeZone.Business.Exceptions.UserExceptions;

public class LoginFailedException : Exception
{
    public LoginFailedException():base("User failed for some reasons")
    {
    }

    public LoginFailedException(string? message) : base(message)
    {
    }
}
