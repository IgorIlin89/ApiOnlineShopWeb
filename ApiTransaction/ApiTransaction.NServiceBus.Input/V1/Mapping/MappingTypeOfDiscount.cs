using OnlineShopWeb.Messages.V1;
using Transaction.Domain;
using Transaction.Domain.Exceptions;

namespace Transaction.NServiceBus.Input.V1.Mapping;

public static class MappingTypeOfDiscount
{
    public static TypeOfDiscount MapToTypeOfDiscount(this TypeOfDiscountDto typeOfDiscountDto)
    {
        return typeOfDiscountDto switch
        {
            TypeOfDiscountDto.Percentage => TypeOfDiscount.Percentage,
            TypeOfDiscountDto.Total => TypeOfDiscount.Total,
            _ => throw new EnumException($"Conversion from TypeOfDiscountDto to TypeOfDiscount failed")
        };
    }
}
