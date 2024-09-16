namespace Transaction.Application.Interfaces.Service
{
    public interface ITransactionToCouponsDto
    {
        double AmountOfDiscount { get; set; }
        string Code { get; set; }
        int CouponId { get; set; }
        int Id { get; set; }
        int TransactionDtoId { get; set; }
        TypeOfDiscountDto TypeOfDiscountDto { get; set; }
    }
}