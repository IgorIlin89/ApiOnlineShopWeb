using Microsoft.EntityFrameworkCore;
using Transaction.Domain;

namespace Transaction.Database;

public class TransactionContext : DbContext
{
    public TransactionContext(DbContextOptions<TransactionContext> context)
        : base(context)
    {

    }

    public DbSet<Domain.Transaction> Transaction { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductInCart>()
            .Property(o => o.PricePerProduct)
            .HasColumnType("decimal(10,2)");

        modelBuilder.Entity<Domain.Transaction>()
            .HasMany(o => o.ProductsInCart)
            .WithOne()
            .HasForeignKey(o => o.TransactionId)
            .IsRequired();

        modelBuilder.Entity<Domain.Transaction>()
            .HasMany(o => o.Coupons)
            .WithOne()
            .HasForeignKey(o => o.TransactionId);
    }
}
