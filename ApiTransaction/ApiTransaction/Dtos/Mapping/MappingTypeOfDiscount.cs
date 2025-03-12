using Transaction.Domain.Exceptions;

namespace Transaction.Service.Dtos.Mapping;

public static class MappingTypeOfDiscount
{
    public static Domain.TypeOfDiscount MapToTypeOfDiscount(this TypeOfDiscountTransactionCouponDto typeOfDiscountDto)
    {
        return typeOfDiscountDto switch
        {
            TypeOfDiscountTransactionCouponDto.Percentage => Domain.TypeOfDiscount.Percentage,
            TypeOfDiscountTransactionCouponDto.Total => Domain.TypeOfDiscount.Total,
            _ => throw new EnumException("Conversion from TypeOfDiscountDto to TypeOfDiscount failed")
        };
    }

    public static TypeOfDiscountTransactionCouponDto MapToTypeOfDiscountDto(this Domain.TypeOfDiscount typeOfDiscount)
    {
        return typeOfDiscount switch
        {
            Domain.TypeOfDiscount.Percentage => TypeOfDiscountTransactionCouponDto.Percentage,
            Domain.TypeOfDiscount.Total => TypeOfDiscountTransactionCouponDto.Total,
            _ => throw new EnumException("Conversion from TypeOfDiscount to TypeOfDiscountDto failed")
        };
    }
}
