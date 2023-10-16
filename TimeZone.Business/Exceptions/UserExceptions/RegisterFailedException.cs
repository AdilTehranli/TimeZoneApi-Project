namespace TimeZone.Business.Exceptions.UserExceptions;

public class RegisterFailedException : Exception
{
    public RegisterFailedException():base("Register failed please try again")
    {
    }

    public RegisterFailedException(string? message) : base(message)
    {
    }
}
