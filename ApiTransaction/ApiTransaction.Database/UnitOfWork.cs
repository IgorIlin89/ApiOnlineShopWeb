using Transaction.Domain.Interfaces;

namespace Transaction.Database;

public class UnitOfWork : IUnitOfWork
{
    private readonly TransactionContext _dbContext;
    private readonly ITransactionRepository _transactionRepository;

    public UnitOfWork(TransactionContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ITransactionRepository TransactionRepository =>
        _transactionRepository is null ? new TransactionRepository(_dbContext) : _transactionRepository;

    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Dispose() => _dbContext.Dispose();

    public ValueTask DisposeAsync() => _dbContext.DisposeAsync();
}
