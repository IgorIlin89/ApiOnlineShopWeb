using ApiCouponProduct.Database.Interfaces;

namespace ApiCouponProduct.Database;

internal class UnitOfWork(ApiCouponProductContext DbContext) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
    {
        await DbContext.SaveChangesAsync(cancellationToken);
    }
}
