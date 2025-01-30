using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Handlers.Interfaces;

public interface IGetCouponListCommandHandler
{
    Task<List<Coupon>> HandleAsync(CancellationToken cancellationToken);
}