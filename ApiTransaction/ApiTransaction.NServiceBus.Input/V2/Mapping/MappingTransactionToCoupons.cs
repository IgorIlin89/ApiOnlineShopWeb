using OnlineShopWeb.Messages.V2;
using Transaction.Domain;

namespace Transaction.NServiceBus.Input.V2.Mapping;

public static class MappingTransactionToCoupons
{
    public static Coupon MapToDomain(this TransactionCouponDto dto)
       => new Coupon
       {
           Code = dto.Code,
           AmountOfDiscount = dto.AmountOfDiscount,
           TypeOfDiscount = dto.TypeOfDiscount.MapToDomain()
       };


    public static IReadOnlyCollection<Coupon> MapToDomain(this IReadOnlyCollection<TransactionCouponDto> dtoList)
        => dtoList.Select(o => o.MapToDomain()).ToList();
}
