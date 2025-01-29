using Transaction.Domain;

namespace Transaction.Application.Commands;

public record AddTransactionCommandGrpc(int UserId,
    List<ProductInCart> ProductInCartList,
    List<TransactionToCoupons> couponsUsed)
{
}
