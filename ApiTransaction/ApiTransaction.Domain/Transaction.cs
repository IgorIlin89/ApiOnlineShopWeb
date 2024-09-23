namespace Transaction.Domain;

public class Transaction
{
    public int Id { get; set; }
    //public int Id { get; private init; }
    //public int Id { get; private set; }
    public int UserId { get; set; }
    public DateTimeOffset PaymentDate { get; set; }
    public decimal FinalPrice { get; private set; }

    //When using ICollection, EF Core give an Error
    public List<ProductInCart> ProductsInCart { get; set; }
    public List<TransactionToCoupons>? Coupons { get; set; }

    //public IReadOnlyCollection<ProductInCart> ProductsInCart { get; set; }
    //public IReadOnlyCollection<ProductInCart> ProductsInCart { get; set; }

    private Transaction()
    {

    }

    public static Transaction Create(int userId, List<ProductInCart> productsInCart,
        List<TransactionToCoupons>? couponsUsed)
    {
        var result = new Transaction
        {
            UserId = userId,
            ProductsInCart = productsInCart,
            Coupons = couponsUsed,
            FinalPrice = CalculateFinalPrice(productsInCart, couponsUsed)
        };


        return result;
    }

    private static decimal CalculateFinalPrice(List<ProductInCart> products,
        List<TransactionToCoupons>? coupons)
    {
        decimal result = new();

        foreach (var element in products)
        {
            result += element.PricePerProduct * element.Count;
        }

        if (coupons is not null)
        {
            foreach (var element in coupons)
            {
                if (element.TypeOfDiscount == TypeOfDiscount.Percentage)
                {
                    result = (100m - (decimal)element.AmountOfDiscount) * result;
                }
            }
        }

        return result;
    }
}
