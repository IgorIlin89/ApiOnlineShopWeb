namespace Transaction.Application.Interfaces.Service;

public interface IProductInCartDto
{
    int Count { get; set; }
    int Id { get; set; }
    decimal PricePerProduct { get; set; }
    int ProductId { get; set; }
    int TransactionId { get; set; }
}