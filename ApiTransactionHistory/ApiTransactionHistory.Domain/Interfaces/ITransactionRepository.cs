namespace Transaction.Domain.Interfaces;

public interface ITransactionRepository
{
    Transaction Add(Transaction transaction);
    List<Transaction> GetList(int id);
}