using Transaction.Application.Interfaces.Service;

namespace Transaction.Service.Dtos;

public class AddTransactionDto : IAddTransactionDto
{
    public int? Id { get; set; }
    public int? TransactionToCouponsId { get; set; }
    public int UserId { get; set; }
    public DateTimeOffset PaymentDate { get; set; }
    public decimal? FinalPrice { get; set; }
    public List<IProductInCartDto> ProductsInCart { get; set; }
    public List<ITransactionToCouponsDto>? Coupons { get; set; }
    //List<ITransactionToCouponsDto>? IAddTransactionDto.Coupons { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    //List<IProductInCartDto> IAddTransactionDto.ProductsInCart { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
}
