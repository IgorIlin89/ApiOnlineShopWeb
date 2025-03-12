using Google.Protobuf.Collections;
using GrpcTestService.Contracts;

namespace Transaction.Service.Services;

public static class MappingToDomain
{
    public static Transaction.Domain.TypeOfDiscount MapToDomain(
        this int typeOfDiscount)
        => typeOfDiscount switch
        {
            1 => Transaction.Domain.TypeOfDiscount.Percentage,
            2 => Transaction.Domain.TypeOfDiscount.Total,
            _ => throw new NotImplementedException(),
        };

    public static Transaction.Domain.Coupon MapToDomain(this TransactionCoupon coupon)
        => new Transaction.Domain.Coupon
        {
            Code = coupon.Code,
            AmountOfDiscount = coupon.AmountOfDiscount,
            TypeOfDiscount = coupon.TypeOfDiscount.MapToDomain(),
        };

    public static List<Transaction.Domain.Coupon> MapToDomain(this RepeatedField<TransactionCoupon> list)
        => list.Select(o => o.MapToDomain()).ToList();

    public static Transaction.Domain.ProductInCart MapToDomain(this ProductInCart productInCart)
        => new Domain.ProductInCart
        {
            Count = productInCart.Count,
            ProductId = productInCart.ProductId,
            PricePerProduct = Decimal.Parse(productInCart.PricePerProduct)
        };

    public static List<Transaction.Domain.ProductInCart> MapToDomain(this RepeatedField<ProductInCart> list)
        => list.Select(o => o.MapToDomain()).ToList();
}
