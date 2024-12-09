using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Commands;

public record AddCouponCommand(string Code,
    double AmountOfDiscount, TypeOfDiscount TypeOfDiscount,
    long? MaxNumberOfUses, DateTimeOffset StartDate,
    DateTimeOffset EndDate)
{
}
