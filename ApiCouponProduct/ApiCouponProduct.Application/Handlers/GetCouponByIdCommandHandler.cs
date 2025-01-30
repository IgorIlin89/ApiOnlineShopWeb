using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Application.Handlers.Interfaces;
using ApiCouponProduct.Database.Interfaces;
using ApiCouponProduct.Domain;
namespace ApiCouponProduct.Application.Handlers;

public class GetCouponByIdCommandHandler(IUnitOfWork UnitOfWork, ICouponRepository Repository)
    : IGetCouponByIdCommandHandler
{
    public async Task<Coupon> Handle(GetCouponByIdCommand command,
        CancellationToken cancellationToken)
    {
        var coupon = await Repository.GetCouponById(command.Id, cancellationToken);
        return coupon;
    }
}
