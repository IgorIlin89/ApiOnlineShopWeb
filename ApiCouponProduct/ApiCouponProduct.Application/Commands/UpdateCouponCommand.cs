using ApiCouponProduct.Domain;

namespace ApiCouponProduct.Application.Commands;

public record UpdateCouponCommand(int Id, string Code,
    double AmountOfDiscount, TypeOfDiscount TypeOfDiscount,
    long? MaxNumberOfUses, DateTimeOffset StartDate,
    DateTimeOffset EndDate)
{
}
