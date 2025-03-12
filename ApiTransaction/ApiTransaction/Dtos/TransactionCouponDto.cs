namespace Transaction.Service.Dtos;

public class TransactionCouponDto
{
    public string Code { get; set; }
    public double AmountOfDiscount { get; set; }
    public TypeOfDiscountTransactionCouponDto TypeOfDiscountDto { get; set; }
}
