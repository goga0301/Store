using Banking.Domain.Entities;
using Banking.Infrastructure.Repository.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Banking.Infrastructure.Repository.DbContexts
{
    public class BankingDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public BankingDbContext(DbContextOptions<BankingDbContext> options) : base(options)
        {
            
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("BankingDb");
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CardConfiguration).Assembly);
            modelBuilder.Model.SetMaxIdentifierLength(30);

            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());
            }

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
