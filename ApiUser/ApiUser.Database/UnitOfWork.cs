using ApiUser.Database.Interfaces;

namespace ApiUser.Database;

public class UnitOfWork(ApiUserContext DbContext) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await DbContext.SaveChangesAsync();
    }
}
