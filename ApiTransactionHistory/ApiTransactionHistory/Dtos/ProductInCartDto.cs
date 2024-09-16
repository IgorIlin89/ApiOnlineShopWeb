using Transaction.Application.Interfaces.Service;

namespace Transaction.Domain.Dtos;

public class ProductInCartDto : IProductInCartDto
{
    public int Id { get; set; }
    public int Count { get; set; }
    public int ProductId { get; set; }
    public decimal PricePerProduct { get; set; }
    public int TransactionId { get; set; }
}
