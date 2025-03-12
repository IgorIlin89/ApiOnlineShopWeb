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

    public static TransactionCoupon MapToGrpc(this Transaction.Domain.Coupon coupon)
        => new TransactionCoupon
        {
            Code = coupon.Code,
            AmountOfDiscount = coupon.AmountOfDiscount,
            TypeOfDiscount = coupon.TypeOfDiscount.MapToGrpc(),
        };

    public static ProductInCart MapToGrpc(this Transaction.Domain.ProductInCart productInCart)
       => new ProductInCart
       {
           ProductId = productInCart.ProductId,
           Count = productInCart.Count,
           PricePerProduct = productInCart.PricePerProduct.ToString()
       };

    public static GrpcTestService.Contracts.Transaction MapToGrpc(this Transaction.Domain.Transaction transaction)
    {
        var result = new GrpcTestService.Contracts.Transaction
        {
            Id = transaction.Id,
            UserId = transaction.UserId,
            PaymentDate = transaction.PaymentDate.ToString(),
            FinalPrice = transaction.FinalPrice.ToString(),
            ProductsInCart = { transaction.ProductsInCart.Select(o => o.MapToGrpc()) },
            CouponList = { transaction.Coupons.Select(o => o.MapToGrpc()) }
        };

        return result;
    }

    public static GrpcTestService.Contracts.TransactionList MapToGrpcList(
        this IReadOnlyCollection<Transaction.Domain.Transaction> list)
    {

        return new TransactionList
        {
            TransactionList_ = { list.Select(o => o.MapToGrpc()) }
        };
    }
}
