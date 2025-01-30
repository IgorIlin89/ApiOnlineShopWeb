using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Handlers.Interfaces;

public interface IGetCouponListCommandHandler
{
    Task<List<Coupon>> Handle(CancellationToken cancellationToken);
}