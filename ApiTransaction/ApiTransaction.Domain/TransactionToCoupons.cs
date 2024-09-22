namespace Transaction.Domain;

public class TransactionToCoupons
{
    public int Id { get; set; }
    public int TransactionId { get; set; }
    //public Transaction Transaction { get; set; }
    public int CouponId { get; set; }
    public string Code { get; set; }
    public double AmountOfDiscount { get; set; }
    public TypeOfDiscount TypeOfDiscount { get; set; }
}
