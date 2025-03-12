using Transaction.Domain;

namespace Transaction.Application.Commands;

public record AddTransactionCommand(int UserId,
    IReadOnlyCollection<ProductInCart> ProductInCartList,
    IReadOnlyCollection<Coupon> CouponsUsed)
{
}
