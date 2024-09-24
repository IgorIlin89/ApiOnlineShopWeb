namespace Transaction.Service.Dtos;

public class AddTransactionDto
{
    public int UserId { get; init; }
    public List<AddProductInCartDto> AddProductsInCartDto { get; init; }
    public List<AddTransactionToCouponsDto>? AddCouponsDto { get; init; }
}
