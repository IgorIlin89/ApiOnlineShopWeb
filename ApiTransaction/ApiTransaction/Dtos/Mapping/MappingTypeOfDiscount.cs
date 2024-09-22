using Transaction.Domain;
using Transaction.Domain.Exceptions;

namespace Transaction.Service.Dtos.Mapping;

public static class MappingTypeOfDiscount
{
    public static TypeOfDiscount MapToTypeOfDiscount(this TypeOfDiscountDto typeOfDiscountDto)
    {
        return typeOfDiscountDto switch
        {
            TypeOfDiscountDto.Percentage => TypeOfDiscount.Percentage,
            TypeOfDiscountDto.Total => TypeOfDiscount.Total,
            _ => throw new EnumException("Conversion from TypeOfDiscountDto to TypeOfDiscount failed")
        };
    }

    public static TypeOfDiscountDto MapToTypeOfDiscountDto(this TypeOfDiscount typeOfDiscount)
    {
        return typeOfDiscount switch
        {
            TypeOfDiscount.Percentage => TypeOfDiscountDto.Percentage,
            TypeOfDiscount.Total => TypeOfDiscountDto.Total,
            _ => throw new EnumException("Conversion from TypeOfDiscount to TypeOfDiscountDto failed")
        };
    }
}
