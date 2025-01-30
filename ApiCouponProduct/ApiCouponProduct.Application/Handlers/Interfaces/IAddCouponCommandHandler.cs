using ApiCouponProduct.Application.Commands;
using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Handlers.Interfaces;

public interface IAddCouponCommandHandler
{
    Task<Coupon> Handle(AddCouponCommand command, CancellationToken cancellationToken);
}