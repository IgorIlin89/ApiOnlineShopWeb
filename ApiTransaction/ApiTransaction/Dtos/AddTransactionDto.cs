namespace Transaction.Service.Dtos;

public class AddTransactionDto
{
    public int? Id { get; set; }
    //public int? TransactionToCouponsId { get; set; }
    public int UserId { get; set; }
    public DateTimeOffset PaymentDate { get; set; }
    public decimal? FinalPrice { get; set; }
    public List<ProductInCartDto> ProductsInCart { get; set; }
    public List<TransactionToCouponsDto>? Coupons { get; set; }
    //List<ITransactionToCouponsDto>? IAddTransactionDto.Coupons { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //List<IProductInCartDto> IAddTransactionDto.ProductsInCart { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
