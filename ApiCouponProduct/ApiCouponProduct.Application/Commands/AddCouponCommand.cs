using CouponAdapter;

namespace ApiCouponProduct.Application.Commands;

public record AddCouponCommand
{
    //TODO
    //[JsonPropertyName("Test")]
    public string Code { get; set; } = null!;
    public double AmountOfDiscount { get; set; }
    public TypeOfDiscountDtoAdapter TypeOfDiscount { get; set; }
    public long? MaxNumberOfUses { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }

    public AddCouponCommand(string code, double amountOfDiscount,
        TypeOfDiscountDtoAdapter typeOfDiscount, long? maxNumberOfUses,
        DateTimeOffset startDate, DateTimeOffset endDate)
    {
        Code = code;
        AmountOfDiscount = amountOfDiscount;
        TypeOfDiscount = typeOfDiscount;
        MaxNumberOfUses = maxNumberOfUses;
        StartDate = startDate;
        EndDate = endDate;
    }
}
