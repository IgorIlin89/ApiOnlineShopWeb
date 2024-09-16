using Transaction.Application.Interfaces.Service;

namespace Transaction.Application.Commands;

public record AddTransactionCommand
{
    public readonly Domain.Transaction TransactionToAdd;

    public AddTransactionCommand(IAddTransactionDto addTransactionDto)
    {
        //public AddTransactionCommand(List<ProductInCard> etc, IAddTransactionDto addTransactionDto)
        //TODO TransactionToAdd = addTransactionDto.MapToTransaction();
        TransactionToAdd.PaymentDate = DateTime.Now;
    }
}
