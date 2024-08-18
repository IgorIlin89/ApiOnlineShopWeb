namespace ApiTransactionHistory.Domain;

public class TransactionHistory
{
    public int Id { get; set; }
    //public int Id { get; private init; }
    //public int Id { get; private set; }
    public int UserId { get; set; }
    public DateTimeOffset PaymentDate { get; set; }
    public decimal? FinalPrice { get; private set; }
    public TransactionHistoryToCoupons? Coupons { get; set; }

    //When using ICollection, EF Core give an Error
    public List<ProductInCart> ProductsInCart { get; set; }

    //Make Enum of TypeOfDiscount´, make sure it cant get values that are not allowed

    //TODO One To Many with Coupons look into
    //public IReadOnlyCollection<ProductInCart> ProductsInCart { get; set; }
    //public IReadOnlyCollection<ProductInCart> ProductsInCart { get; set; }

    //private TransactionHistory()
    //{

    //}

    public static TransactionHistory Create(int UserId,
        List<ProductInCart> products)
    {
        var result = new TransactionHistory
        {
            Id = 1,
            UserId = 3,
            ProductsInCart = new List<ProductInCart>(),
            FinalPrice = CalculateFinalPrice(products)
        };
        //TransactionHistory without Products in cart no sense, without price 
        result.ProductsInCart.Add(new ProductInCart
        {

        });

        return result;
    }
    //internal static decimal CalculateFinalPrice()
    //{
    //    return CalculateFinalPrice(ProductsInCart);
    //}

    public static decimal CalculateFinalPrice(List<ProductInCart> products)
    {
        decimal result = new();

        //MappingTransactionHistory.AccessAuthorization(this);

        foreach (var element in products)
        {
            result += element.PricePerProduct * element.Count;
        }

        //TODO Coupons implementation with data from OnlineshopWeb

        return result;
    }

    //public decimal CalculateFinalPrice()
    //{

    //}
}
