namespace ApiTransactionHistory.Domain;

public class TransactionHistoryToCoupons
{
    public int Id { get; set; }
    public int TransactionHistoryId { get; set; }
    public TransactionHistory TransactionHistory { get; set; }
    public int CouponId { get; set; }
    public string Code { get; set; }
    public double AmountOfDiscount { get; set; }
    public TypeOfDiscount TypeOfDiscount { get; set; }
}
