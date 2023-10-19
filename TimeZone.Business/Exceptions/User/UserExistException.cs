namespace TimeZone.Business.Exceptions.UserException;

public class UserExistException : Exception
{
    public UserExistException() : base("Username or Email already exist")
    {
    }

    public UserExistException(string? message) : base(message)
    {
    }
}
