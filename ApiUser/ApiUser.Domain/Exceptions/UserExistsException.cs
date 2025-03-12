namespace ApiUser.Domain.Exceptions;

public class UserExistsException : Exception
{
    public UserExistsException(string message)
        : base(message)
    {

    }

    public UserExistsException(string message, Exception exception)
        : base(message, exception)
    {

    }
}
