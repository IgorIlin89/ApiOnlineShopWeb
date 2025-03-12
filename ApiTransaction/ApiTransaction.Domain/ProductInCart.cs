namespace Transaction.Domain;

public class ProductInCart
{
    public int ProductId { get; set; }
    public int Count { get; set; }
    public decimal PricePerProduct { get; set; }
}
