namespace Transaction.Domain.Interfaces;

public interface IUnitOfWork
{
    ITransactionRepository TransactionRepository { get; }
    Task SaveChangesAsync(CancellationToken cancellationToken);
}