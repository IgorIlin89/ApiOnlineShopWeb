namespace Transaction.Domain;

public class Transaction
{
    public int Id { get; }
    public int UserId { get; private init; }
    public DateTimeOffset PaymentDate { get; private init; }
    public decimal FinalPrice { get; private init; }
    public IReadOnlyCollection<ProductInCart> ProductsInCart { get; private init; }
    public IReadOnlyCollection<TransactionToCoupons>? Coupons { get; private init; }

    //When using ICollection, EF Core give an Error

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
            PaymentDate = DateTime.Now,
            FinalPrice = CalculateFinalPrice(productsInCart, couponsUsed),
            ProductsInCart = productsInCart,
            Coupons = couponsUsed,
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
                    result = ((100m - (decimal)element.AmountOfDiscount) / 100) * result;
                }
                else if (element.TypeOfDiscount == TypeOfDiscount.Total)
                {
                    result -= (decimal)element.AmountOfDiscount;
                }
            }
        }

        return result;
    }
}
