using ApiCouponProduct.Application.Handlers.Interfaces;
using ApiCouponProduct.Database.Interfaces;
using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Handlers;

public class GetCouponListCommandHandler(ICouponRepository Repository) : IGetCouponListCommandHandler
{
    public async Task<List<Coupon>> Handle(CancellationToken cancellationToken)
    {
        return await Repository.GetCouponListAsync(cancellationToken);
    }
}
