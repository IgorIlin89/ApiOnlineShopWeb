namespace ApiCouponProduct.Database.Interfaces;

public interface IUnitOfWork
{
    Task SaveChanges(CancellationToken cancellationToken);
}