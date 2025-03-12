using OnlineShopWeb.Messages.V1;
using Transaction.Domain;

namespace Transaction.NServiceBus.Input.V1.Mapping;

public static class MappingTransactionToCoupons
{
    public static Coupon MapToDomain(this AddTransactionToCouponsDto dto)
    {
        return new Coupon
        {
            Code = dto.Code,
            AmountOfDiscount = dto.AmountOfDiscount,
            TypeOfDiscount = dto.TypeOfDiscountDto.MapToTypeOfDiscount()
        };
    }

    public static List<Coupon> MapToTransactionToCouponsList(this List<AddTransactionToCouponsDto> dtoList)
    {
        var result = new List<Coupon>();

        foreach (var element in dtoList)
        {
            result.Add(element.MapToDomain());
        }

        return result;
    }
}
