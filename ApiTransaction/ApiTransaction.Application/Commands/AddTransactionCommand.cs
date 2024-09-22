using Transaction.Domain;

namespace Transaction.Application.Commands;

public record AddTransactionCommand
{
    public readonly Domain.Transaction TransactionToAdd;

    public AddTransactionCommand(int userId, List<ProductInCart> productsInCart, List<TransactionToCoupons> couponsUsed)
    {
        //TODO TransactionToAdd = addTransactionDto.MapToTransaction();
        TransactionToAdd.PaymentDate = DateTime.Now;
    }
}
