using Transaction.Service.Dtos;

namespace Transaction.Domain.Dtos;

public class TransactionDto
{
    public int Id { get; set; }
    public int? TransactionToCouponsId { get; set; }
    public int UserId { get; set; }
    public DateTimeOffset PaymentDate { get; set; }
    public decimal? FinalPrice { get; set; }
    public TransactionToCouponsDto? CouponsDto { get; set; }
    public ICollection<ProductInCartDto> ProductsInCartDto { get; set; }
}
