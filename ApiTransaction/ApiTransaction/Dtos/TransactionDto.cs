namespace Transaction.Service.Dtos;

public class TransactionDto
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public DateTimeOffset PaymentDate { get; init; }
    public decimal FinalPrice { get; init; }
    public IReadOnlyCollection<ProductInCartDto> ProductsInCartDto { get; init; }
    public IReadOnlyCollection<TransactionCouponDto> CouponsDto { get; init; }
}
