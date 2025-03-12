using Transaction.Domain.Exceptions;

namespace Transaction.Domain;

public class Transaction
{
    public int Id { get; }
    public int UserId { get; private init; }
    public DateTimeOffset PaymentDate { get; private init; }
    public decimal FinalPrice { get; private init; }
    public IReadOnlyCollection<ProductInCart> ProductsInCart { get; private init; }
    public IReadOnlyCollection<Coupon> Coupons { get; private init; }

    //When using ICollection, EF Core give an Error

    //public IReadOnlyCollection<ProductInCart> ProductsInCart { get; set; }
    //public IReadOnlyCollection<ProductInCart> ProductsInCart { get; set; }

    private Transaction()
    {

    }

    public static Transaction Create(int userId, IReadOnlyCollection<ProductInCart> productsInCart,
        IReadOnlyCollection<Coupon> couponsUsed)
    {
        if (productsInCart.Count == 0)
        {
            throw new TransactionException("Exception because no Product");
        }

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

    private static decimal CalculateFinalPrice(IReadOnlyCollection<ProductInCart> products,
        IReadOnlyCollection<Coupon> coupons)
    {
        decimal result = new();

        foreach (var element in products)
        {
            result += element.PricePerProduct * element.Count;
        }

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

        return result;
    }
}
