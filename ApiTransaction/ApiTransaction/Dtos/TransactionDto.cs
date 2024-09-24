namespace Transaction.Service.Dtos;

public class TransactionDto
{
    public int Id { get; init; }
    public int UserId { get; init; }
    public DateTimeOffset PaymentDate { get; init; }
    public decimal FinalPrice { get; init; }
    public List<ProductInCartDto> ProductsInCartDto { get; init; }
    public List<TransactionToCouponsDto>? CouponsDto { get; init; }
}
