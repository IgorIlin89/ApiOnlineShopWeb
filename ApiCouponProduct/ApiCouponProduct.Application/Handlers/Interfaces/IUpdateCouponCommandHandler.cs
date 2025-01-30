using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Handlers.Interfaces;

public interface IUpdateCouponCommandHandler
{
    Task<Coupon> HandleAsync(UpdateCouponCommand command, CancellationToken cancellationToken);
}