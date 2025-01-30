namespace Transaction.Domain.Interfaces;

public interface ITransactionRepository
{
    Task<Domain.Transaction> AddAsync(Transaction transaction, CancellationToken cancellationToken);
    Task<List<Transaction>> GetListAsync(int id, CancellationToken cancellationToken);
}