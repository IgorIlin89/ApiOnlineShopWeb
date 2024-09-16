namespace Transaction.Application.Commands;

public record GetTransactionListCommand
{
    public int Id;
    public GetTransactionListCommand(int id)
    {
        Id = id;
    }
}
