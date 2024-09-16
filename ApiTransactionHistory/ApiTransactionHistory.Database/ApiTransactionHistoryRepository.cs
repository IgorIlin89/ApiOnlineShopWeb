using Microsoft.EntityFrameworkCore;
using Transaction.Domain.Interfaces;

namespace Transaction.Database;

internal class TransactionRepository : ITransactionRepository
{
    private readonly TransactionContext _context;
    public TransactionRepository(TransactionContext context)
    {
        _context = context;
    }

    public List<Domain.Transaction> GetList(int id)
    {
        return _context.Transaction
            .Include(o => o.ProductsInCart)
            .Include(o => o.Coupons)
            .Where(o => o.UserId == id)
            .ToList();
    }

    public Domain.Transaction Add(Domain.Transaction transaction)
    {
        var result = _context.Transaction.Add(transaction);
        return result.Entity;
    }
}
