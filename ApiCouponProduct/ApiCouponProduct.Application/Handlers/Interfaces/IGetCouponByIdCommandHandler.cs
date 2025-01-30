using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Handlers.Interfaces;

public interface IGetCouponByIdCommandHandler
{
    Task<Coupon> HandleAsync(GetCouponByIdCommand command, CancellationToken cancellationToken);
}