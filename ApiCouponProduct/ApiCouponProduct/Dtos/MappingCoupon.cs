using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Dtos;

public static class MappingCoupon
{
    public static AddCouponDto MapToDto(this Coupon coupon) =>
        new AddCouponDto
        {
            CouponId = coupon.Id,
            Code = coupon.Code,
            AmountOfDiscount = coupon.AmountOfDiscount,
            TypeOfDiscount = coupon.TypeOfDiscount,
            MaxNumberOfUses = coupon.MaxNumberOfUses,
            StartDate = coupon.StartDate,
            EndDate = coupon.EndDate
        };

    public static List<AddCouponDto> MapToDtoList(this List<Coupon> couponList) =>
        couponList.Select(o => o.MapToDto()).ToList();
    public static Coupon MapToCoupon(this AddCouponDto couponDto) =>
        new Coupon
        {
            Id = couponDto.CouponId is null ? 0 : couponDto.CouponId.Value,
            Code = couponDto.Code,
            AmountOfDiscount = couponDto.AmountOfDiscount,
            TypeOfDiscount = couponDto.TypeOfDiscount,
            MaxNumberOfUses = couponDto.MaxNumberOfUses,
            StartDate = couponDto.StartDate,
            EndDate = couponDto.EndDate
        };
    public static Coupon MapToCoupon(this UpdateCouponDto updateCouponDto) =>
        new Coupon
        {
            Id = updateCouponDto.CouponId,
            Code = updateCouponDto.Code,
            AmountOfDiscount = updateCouponDto.AmountOfDiscount,
            TypeOfDiscount = updateCouponDto.TypeOfDiscount,
            MaxNumberOfUses = updateCouponDto.MaxNumberOfUses,
            StartDate = updateCouponDto.StartDate,
            EndDate = updateCouponDto.EndDate,
        };
}
