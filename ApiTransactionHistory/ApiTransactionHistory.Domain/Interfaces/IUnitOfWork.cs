namespace Transaction.Domain.Interfaces;

public interface IUnitOfWork
{
    void SaveChanges();
}