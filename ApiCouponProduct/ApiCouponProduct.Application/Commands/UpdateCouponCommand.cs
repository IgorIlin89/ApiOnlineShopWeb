using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Commands;

public record UpdateCouponCommand
{
    public Coupon CouponToUpdate { get; init; }

    public UpdateCouponCommand(Coupon updateCouponDto)
    {
        CouponToUpdate = updateCouponDto;
    }
}
