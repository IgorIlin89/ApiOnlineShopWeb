using Microsoft.Extensions.DependencyInjection;
using Transaction.Domain.Interfaces;

namespace Transaction.Database;

public class UnitOfWorkFactory : IUnitOfWorkFactory
{
    private readonly IServiceProvider _serviceProvider;
    private IUnitOfWork _unitOfWork;
    public UnitOfWorkFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public IUnitOfWork Create()
    {
        if (_unitOfWork is null)
        {
            var dbContext = _serviceProvider.GetRequiredService<TransactionContext>();

            _unitOfWork = new UnitOfWork(dbContext);
        }
        return _unitOfWork;
    }
}
