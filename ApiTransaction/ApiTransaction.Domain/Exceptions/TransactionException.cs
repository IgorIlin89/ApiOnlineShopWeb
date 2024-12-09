namespace Transaction.Domain.Exceptions;

public class TransactionException : Exception
{
    public TransactionException(string message)
        : base(message)
    {

    }

    public TransactionException(string message, Exception exception)
        : base(message, exception)
    {

    }
}
