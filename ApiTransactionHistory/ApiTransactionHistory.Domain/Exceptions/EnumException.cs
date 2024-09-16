namespace Transaction.Domain.Exceptions;

class EnumException : Exception
{
    public EnumException(string message)
        : base(message)
    {

    }

    public EnumException(string message, Exception exception)
        : base(message, exception)
    {

    }
}
