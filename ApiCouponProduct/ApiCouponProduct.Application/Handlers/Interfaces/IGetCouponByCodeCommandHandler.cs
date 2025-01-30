using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Handlers.Interfaces;

public interface IGetCouponByCodeCommandHandler
{
    Task<Coupon> HandleAsync(GetCouponByCodeCommand command, CancellationToken cancellationToken);
}