using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Application.Handlers.Interfaces;
using ApiCouponProduct.Database.Interfaces;
using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Handlers;

public class GetCouponByCodeCommandHandler(IUnitOfWork UnitOfWork, ICouponRepository Repository)
    : IGetCouponByCodeCommandHandler
{
    public async Task<Coupon> HandleAsync(GetCouponByCodeCommand command,
        CancellationToken cancellationToken)
    {
        var coupon = await Repository.GetCouponByCodeAsync(command.Code, cancellationToken);
        return coupon;
    }
}
