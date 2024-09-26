using OnlineShopWeb.Messages.V1;
using Transaction.Domain;

namespace Transaction.NServiceBus.Input.V1.Mapping;

public static class MappingTransactionToCoupons
{
    public static TransactionToCoupons MapToTransactionToCoupons(this AddTransactionToCouponsDto dto)
    {
        return new TransactionToCoupons
        {
            CouponId = dto.CouponId,
            Code = dto.Code,
            AmountOfDiscount = dto.AmountOfDiscount,
            TypeOfDiscount = dto.TypeOfDiscountDto.MapToTypeOfDiscount()
        };
    }

    public static List<TransactionToCoupons> MapToTransactionToCouponsList(this List<AddTransactionToCouponsDto> dtoList)
    {
        var result = new List<TransactionToCoupons>();

        foreach (var element in dtoList)
        {
            result.Add(element.MapToTransactionToCoupons());
        }

        return result;
    }
}
