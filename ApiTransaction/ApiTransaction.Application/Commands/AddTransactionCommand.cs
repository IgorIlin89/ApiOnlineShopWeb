using Transaction.Domain;

namespace Transaction.Application.Commands;

public record AddTransactionCommand
{
    public readonly Domain.Transaction TransactionToAdd;

    public AddTransactionCommand(int userId, List<ProductInCart> addProductsInCart, List<TransactionToCoupons> addCouponsUsed)
    {
        TransactionToAdd = Transaction.Domain.Transaction.Create(userId, addProductsInCart, addCouponsUsed);


        //Transaction.Domain.Transaction.Create()
    }
}
