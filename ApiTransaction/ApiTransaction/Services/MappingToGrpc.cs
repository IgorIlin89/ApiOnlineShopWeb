using GrpcTestService.Contracts;

namespace Transaction.Service.Services;

public static class MappingToGrpc
{
    public static int MapToGrpc(
    this Transaction.Domain.TypeOfDiscount typeOfDiscount)
    => typeOfDiscount switch
    {
        Transaction.Domain.TypeOfDiscount.Percentage => 1,
        Transaction.Domain.TypeOfDiscount.Total => 2,
        _ => throw new NotImplementedException(),
    };

    public static Coupon MapToGrpc(this Transaction.Domain.TransactionToCoupons coupon)
        => new Coupon
        {
            Id = coupon.CouponId,
            Code = coupon.Code,
            AmountOfDiscount = coupon.AmountOfDiscount,
            TypeOfDiscount = coupon.TypeOfDiscount.MapToGrpc(),
        };

    public static ProductInCart MapToGrpc(this Transaction.Domain.ProductInCart productInCart)
       => new ProductInCart
       {
       };

    public static List<Coupon> MapToGrpc(this IReadOnlyCollection<Transaction.Domain.TransactionToCoupons> list)
        => list.Select(o => o.MapToGrpc()).ToList();



    public static GrpcTestService.Contracts.Transaction MapToGrpc(this Transaction.Domain.Transaction transaction)
    {
        var result = new GrpcTestService.Contracts.Transaction
        {
            Id = transaction.Id,
            UserId = transaction.UserId,
            PaymentDate = transaction.PaymentDate.ToString(),
            FinalPrice = transaction.FinalPrice.ToString(),
            ProductsInCart = { transaction.ProductsInCart.Select(o => o.MapToGrpc()) },
        };

        if (transaction.Coupons is not null)
        {
            result.CouponList.AddRange(transaction.Coupons.MapToGrpc());
        }

        return result;

    }


}
