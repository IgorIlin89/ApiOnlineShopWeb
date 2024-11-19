namespace CouponAdapter;

public class AddCouponDtoAdapter
{
    public string Code { get; set; } = null!;
    public double AmountOfDiscount { get; set; }
    public TypeOfDiscountDtoAdapter TypeOfDiscount { get; set; }
    public long? MaxNumberOfUses { get; set; }
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
}
