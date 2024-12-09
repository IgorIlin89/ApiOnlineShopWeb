using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Dtos;

public static class MappingCoupon
{
    public static TypeOfDiscountDto MapToDto(this TypeOfDiscount typeOfDiscount) =>
        typeOfDiscount switch
        {
            TypeOfDiscount.Percentage => TypeOfDiscountDto.Percentage,
            TypeOfDiscount.Total => TypeOfDiscountDto.Total,
            _ => throw new NotImplementedException()
        };

    public static TypeOfDiscount MapToDto(this TypeOfDiscountDto typeOfDiscountDto) =>
    typeOfDiscountDto switch
    {
        TypeOfDiscountDto.Percentage => TypeOfDiscount.Percentage,
        TypeOfDiscountDto.Total => TypeOfDiscount.Total,
        _ => throw new NotImplementedException()
    };

    public static CouponDtoController MapToDto(this Coupon coupon) =>
        new CouponDtoController
        {
            CouponId = coupon.Id,
            Code = coupon.Code,
            AmountOfDiscount = coupon.AmountOfDiscount,
            TypeOfDiscount = coupon.TypeOfDiscount.MapToDto(),
            MaxNumberOfUses = coupon.MaxNumberOfUses,
            StartDate = coupon.StartDate,
            EndDate = coupon.EndDate
        };

    public static List<CouponDtoController> MapToDtoList(this List<Coupon> couponList) =>
        couponList.Select(o => o.MapToDto()).ToList();
    public static Coupon MapToCoupon(this CouponDtoController couponDto) =>
        new Coupon
        {
            Id = couponDto.CouponId is null ? 0 : couponDto.CouponId.Value,
            Code = couponDto.Code,
            AmountOfDiscount = couponDto.AmountOfDiscount,
            TypeOfDiscount = couponDto.TypeOfDiscount.MapToDto(),
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
