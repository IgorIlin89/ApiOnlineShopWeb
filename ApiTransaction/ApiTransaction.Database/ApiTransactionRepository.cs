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

    public async Task<List<Domain.Transaction>> GetListAsync(int id,
        CancellationToken cancellationToken)
    {
        return await _context.Transaction
            .Include(o => o.ProductsInCart)
            .Include(o => o.Coupons)
            .Where(o => o.UserId == id)
            .ToListAsync();
    }

    public async Task<Domain.Transaction> AddAsync(Domain.Transaction transaction,
        CancellationToken cancellationToken)
    {
        var result = await _context.Transaction.AddAsync(transaction);
        return result.Entity;
    }
}
