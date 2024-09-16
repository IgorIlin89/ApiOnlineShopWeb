using Transaction.Application.Interfaces.Service;

namespace Transaction.Service.Dtos;

public class TransactionToCouponsDto : ITransactionToCouponsDto
{
    public int Id { get; set; }
    public int TransactionDtoId { get; set; }
    //public Transaction Transaction { get; set; }
    public int CouponId { get; set; }
    public string Code { get; set; }
    public double AmountOfDiscount { get; set; }
    public TypeOfDiscountDto TypeOfDiscountDto { get; set; }
    //TODO Add TypeOfDiscountDto with mapping

}
