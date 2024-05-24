
using Microsoft.EntityFrameworkCore;

namespace StoreDB1.Models
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext()
        {
        }
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
         : base(options)
        {
        }
        public virtual DbSet<Customer> Customers { get; set; }

        public virtual DbSet<Store> Stores { get; set; }

        public virtual DbSet<Sales> Sale { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
         => optionsBuilder.UseSqlServer("Server=localhost;Database=StoreDB1;Trusted_Connection=True;TrustServerCertificate=True;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasKey(e => e.CustomerId).HasName("PK_dbo.Customer");

                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("CustomerId");
            });
            modelBuilder.Entity<Sales>(entity =>
            {
                entity.HasKey(e => e.SalesId).HasName("PK_dbo.Sales");

                entity.ToTable("Sales");

                entity.HasIndex(e => e.CustomerId, "IX_CustomerId");

                entity.HasIndex(e => e.StoreId, "IX_StoreId");
                entity.HasIndex(e => e.ProductId, "IX_ProductId");

                entity.Property(e => e.SalesId).HasColumnName("SalesId");
                entity.Property(e => e.CustomerId).HasColumnName("CustomerId");
                entity.Property(e => e.StoreId).HasColumnName("StoreId");
                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.HasOne(d => d.customer).WithMany(p => p.Sales)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_dbo.Sales_dbo.Customer_CustomerId");

                entity.HasOne(d => d.Store).WithMany(p => p.Sales)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_dbo.Sales_dbo.Store_StoreId");
                entity.HasOne(d => d.Product).WithMany(p => p.Sales)
                   .HasForeignKey(d => d.ProductId)
                   .HasConstraintName("FK_dbo.Sales_dbo.Product_ProductId");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId).HasName("PK_dbo.ProductId");

                entity.ToTable("Product");

                entity.Property(e => e.ProductId)
                    .ValueGeneratedNever()
                    .HasColumnName("ProductId");
            });
            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasKey(e => e.StoreId).HasName("PK_dbo.StoreId");

                entity.ToTable("Store");

                entity.Property(e => e.StoreId)
                    .ValueGeneratedNever()
                    .HasColumnName("StoreId");
            });
        }

    }
}
