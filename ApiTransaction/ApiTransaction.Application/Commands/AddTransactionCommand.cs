using Transaction.Domain;

namespace Transaction.Application.Commands;

public record AddTransactionCommand(int UserId,
    List<ProductInCart> ProductInCartList,
    List<TransactionToCoupons> CouponsUsed)
{
}
