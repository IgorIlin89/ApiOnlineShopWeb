namespace Transaction.Application.Interfaces.Service;

public interface IAddTransactionDto
{
    List<ITransactionToCouponsDto>? Coupons { get; set; }
    decimal? FinalPrice { get; set; }
    int? Id { get; set; }
    DateTimeOffset PaymentDate { get; set; }
    List<IProductInCartDto> ProductsInCart { get; set; }
    int? TransactionToCouponsId { get; set; }
    int UserId { get; set; }
}