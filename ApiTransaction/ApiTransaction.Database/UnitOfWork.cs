using Transaction.Domain.Interfaces;

namespace Transaction.Database;

public class UnitOfWork(TransactionContext DbContext) : IUnitOfWork
{
    public void SaveChanges()
    {
        DbContext.SaveChanges();
    }
}
