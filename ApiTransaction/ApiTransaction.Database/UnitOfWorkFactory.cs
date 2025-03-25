using Microsoft.Extensions.DependencyInjection;
using Transaction.Domain.Interfaces;

namespace Transaction.Database;

public class UnitOfWorkFactory : IUnitOfWorkFactory
{
    private readonly IServiceProvider _serviceProvider;
    public UnitOfWorkFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IUnitOfWork Create()
    {
        var dbContext = _serviceProvider.GetRequiredService<TransactionContext>();

        var unitOfWork = new UnitOfWork(dbContext);
        return unitOfWork;
    }
}
