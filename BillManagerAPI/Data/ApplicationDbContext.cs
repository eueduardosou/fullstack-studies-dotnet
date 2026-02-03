using BillManagerAPI.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BillManagerAPI.Data
{
    public class ApplicationDbContext: IdentityDbContext<IdentityUser>
    {
        // Constructor for DI
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSets represent our tables
        public DbSet<Card> Cards { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<TransactionNature> TransactionNature { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TransactionNature>(entity =>
            {
                entity.HasKey(n => n.Id);
        
                // No MySQL, isso garante que o ID seja gerado como UUID
                entity.Property(n => n.Id)
                    .HasDefaultValueSql("NEWID()"); 
 
                entity.Property(n => n.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });
 
            // Relacionamento na Transaction
            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Id).HasDefaultValueSql("NEWID()");

                entity.Property(t => t.Description)
                    .IsRequired();

                entity.HasOne(t => t.Nature)
                    .WithMany()
                    .HasForeignKey(t => t.NatureId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.HasOne(t => t.Category)
                    .WithMany()
                    .HasForeignKey(t => t.CategoryId)
                    .OnDelete(DeleteBehavior.Restrict)
                    .IsRequired();

                entity.HasOne(t => t.Card)
                    .WithMany()
                    .HasForeignKey(t => t.CardId)
                    .OnDelete(DeleteBehavior.SetNull);
             });

            // 2. Card Mapping
            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
                entity.Property(c => c.BankHolder).HasPrecision(18, 2);
                entity.Property(c => c.Name).HasMaxLength(100).IsRequired();
            });

            // 3. Category Mapping
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(e => e.Id).HasDefaultValueSql("NEWID()");
                entity.Property(c => c.Name).HasMaxLength(50).IsRequired();
            });
        }
    }
}