using ExpenseTracker.Domain;
using ExpenseTracker.Domain.Common;
using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;

namespace ExpenseTracker.Persistence.DatabaseContext;

public class ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : DbContext(options)
{
    public DbSet<Lookup>? Lookups { get; set; }
    public DbSet<Wallet>? Wallets { get; set; }
    public DbSet<Transaction>? Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // this will not work for non-relational databases
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ExpenseDbContext).Assembly);
        
        modelBuilder.Entity<Lookup>().ToCollection("lookups");
        modelBuilder.Entity<Wallet>().ToCollection("wallets");
        modelBuilder.Entity<Transaction>().ToCollection("transactions");
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                     .Where(x => x.State is EntityState.Added or EntityState.Modified))
        {
            entry.Entity.UpdatedDate = DateTime.UtcNow;
            // update Entity updatedBy

            if (entry.State != EntityState.Added) continue;

            entry.Entity.CreatedDate = DateTime.UtcNow;
            // update Entity createdBy
        }
        Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;

        return base.SaveChangesAsync(cancellationToken);
    }
}