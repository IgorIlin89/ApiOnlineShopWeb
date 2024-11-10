using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Commands;

public record AddCouponCommand
{
    public Coupon CouponToAdd { get; init; }

    public AddCouponCommand(Coupon couponToAdd)
    {
        CouponToAdd = couponToAdd;
    }
}
