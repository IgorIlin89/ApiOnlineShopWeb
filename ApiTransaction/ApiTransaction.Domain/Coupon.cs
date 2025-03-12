namespace Transaction.Domain;

public class Coupon
{
    public string Code { get; set; }
    public double AmountOfDiscount { get; set; }
    public TypeOfDiscount TypeOfDiscount { get; set; }
}
