namespace Transaction.Domain;

public class Transaction
{
    public int Id { get; set; }
    //public int Id { get; private init; }
    //public int Id { get; private set; }
    public int UserId { get; set; }
    public DateTimeOffset PaymentDate { get; set; }
    public decimal? FinalPrice { get; private set; }

    //When using ICollection, EF Core give an Error
    public List<ProductInCart> ProductsInCart { get; set; }
    public List<TransactionToCoupons>? Coupons { get; set; }

    //TODO Dtos need to go into service
    //System.Enum.GetValues(typeof(TypeOfDiscount)); not required, work with exception
    //Make Enum of TypeOfDiscount´, make sure it cant get values that are not allowed
    //TypeOfDiscountDTO is required

    //TODO One To Many with Coupons look into
    //public IReadOnlyCollection<ProductInCart> ProductsInCart { get; set; }
    //public IReadOnlyCollection<ProductInCart> ProductsInCart { get; set; }

    private Transaction()
    {

    }

    public static Transaction Create(int UserId,
        List<ProductInCart> products)
    {
        var result = new Transaction
        {
            Id = 1,
            UserId = 3,
            ProductsInCart = new List<ProductInCart>(),
            FinalPrice = CalculateFinalPrice(products)
        };


        //Transaction without Products in cart no sense, without price 
        result.ProductsInCart.Add(new ProductInCart
        {

        });

        return result;
    }
    //internal static decimal CalculateFinalPrice()
    //{
    //    return CalculateFinalPrice(ProductsInCart);
    //}

    private static decimal CalculateFinalPrice(List<ProductInCart> products)
    {
        decimal result = new();

        //MappingTransaction.AccessAuthorization(this);

        foreach (var element in products)
        {
            result += element.PricePerProduct * element.Count;
        }

        //TODO Coupons implementation with data from OnlineshopWeb

        return result;
    }
}
