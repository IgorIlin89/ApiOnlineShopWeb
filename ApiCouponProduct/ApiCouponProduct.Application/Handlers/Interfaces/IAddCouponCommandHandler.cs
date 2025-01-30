using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Handlers.Interfaces;

public interface IAddCouponCommandHandler
{
    Task<Coupon> HandleAsync(AddCouponCommand command, CancellationToken cancellationToken);
}