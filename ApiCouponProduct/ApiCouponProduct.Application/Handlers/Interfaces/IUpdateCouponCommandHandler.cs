using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Handlers.Interfaces;

public interface IUpdateCouponCommandHandler
{
    Task<Coupon> Handle(UpdateCouponCommand command, CancellationToken cancellationToken);
}