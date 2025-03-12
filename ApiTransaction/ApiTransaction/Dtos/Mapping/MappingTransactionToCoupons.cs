using Transaction.Domain;

namespace Transaction.Service.Dtos.Mapping;

public static class MappingTransactionToCoupons
{
    public static Coupon MapToDomain(
        this TransactionCouponDto transactionToCouponsDto) =>
        new Coupon
        {
            Code = transactionToCouponsDto.Code,
            AmountOfDiscount = transactionToCouponsDto.AmountOfDiscount,
            TypeOfDiscount = transactionToCouponsDto.TypeOfDiscountDto.MapToTypeOfDiscount()
        };
    public static TransactionCouponDto MapToDto(
        this Coupon transactionToCoupons) =>
         new TransactionCouponDto
         {
             Code = transactionToCoupons.Code,
             AmountOfDiscount = transactionToCoupons.AmountOfDiscount,
             TypeOfDiscountDto = transactionToCoupons.TypeOfDiscount.MapToTypeOfDiscountDto()
         };

    public static List<Coupon> MapToTransactionToCouponsList(this List<TransactionCouponDto> list) =>
        list.Select(o => o.MapToDomain()).ToList();
    public static List<TransactionCouponDto> MapToDtoList(this IReadOnlyCollection<Coupon> list) =>
        list.Select(o => o.MapToDto()).ToList();
    public static Coupon MapToTransactionToCoupons(this AddCouponsDto dto) =>
        new Coupon
        {
            Code = dto.Code,
            AmountOfDiscount = dto.AmountOfDiscount,
            TypeOfDiscount = dto.TypeOfDiscountDto.MapToTypeOfDiscount()
        };

    public static List<Coupon> MapToCouponsList(this List<AddCouponsDto> dtoList) =>
        dtoList.Select(o => o.MapToTransactionToCoupons()).ToList();
}
