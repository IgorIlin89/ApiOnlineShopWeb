namespace Transaction.Domain.Interfaces;

public interface ITransactionRepository
{
    Transaction Add(Transaction transaction, CancellationToken cancellationToken);
    List<Transaction> GetList(int id);
}