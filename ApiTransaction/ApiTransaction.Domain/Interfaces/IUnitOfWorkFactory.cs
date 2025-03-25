namespace Transaction.Domain.Interfaces;

public interface IUnitOfWorkFactory
{
    IUnitOfWork Create();
}