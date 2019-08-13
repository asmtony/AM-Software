using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StockTrackAspNetCore.Database.EntityModels
{
    public partial class ASMContext : DbContext
    {
        public ASMContext()
        {
        }

        public ASMContext(DbContextOptions<ASMContext> options)
            : base(options)
        {
            
        }

        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Categorys> Categorys { get; set; }
        public virtual DbSet<Lookups> Lookups { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<SupplierProducts> SupplierProducts { get; set; }
        public virtual DbSet<Suppliers> Suppliers { get; set; }
        public virtual DbSet<WebCompanies> WebCompanies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("server=DESKTOP-5TIMTU6;database=ASMTest;trusted_connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Brands>(entity =>
            {
                entity.HasKey(e => e.BrandId)
                    .HasName("PK_brands");

                entity.Property(e => e.DateAdded)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.WebCompany)
                    .WithMany(p => p.Brands)
                    .HasForeignKey(d => d.WebCompanyId)
                    .HasConstraintName("FK_brands_webcompanies");
            });

            modelBuilder.Entity<Categorys>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK_dbo.Categorys");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lookups>(entity =>
            {
                entity.HasKey(e => e.LookupId);

                entity.Property(e => e.DateAdded)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Value).HasMaxLength(200);

                entity.HasOne(d => d.WebCompany)
                    .WithMany(p => p.Lookups)
                    .HasForeignKey(d => d.WebCompanyId)
                    .HasConstraintName("FK_Lookups_webcompanies");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK_products");

                entity.HasIndex(e => e.ProductCode)
                    .HasName("idx_product_productcode");

                entity.HasIndex(e => e.ProductCodeOther)
                    .HasName("idx_product_productcodeOther");

                entity.Property(e => e.Barcode).HasMaxLength(40);

                entity.Property(e => e.DateAdded)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PackSize).HasMaxLength(20);

                entity.Property(e => e.ProductCode).HasMaxLength(40);

                entity.Property(e => e.ProductCodeOther).HasMaxLength(40);

                entity.HasOne(d => d.WebCompany)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.WebCompanyId)
                    .HasConstraintName("FK_products_webcompanies");
            });

            modelBuilder.Entity<SupplierProducts>(entity =>
            {
                entity.HasKey(e => e.SupplierProductId);

                entity.Property(e => e.DateAdded)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SupplierProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_supplierproducts_products");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplierProducts)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_supplierproducts_supplier");

                entity.HasOne(d => d.WebCompany)
                    .WithMany(p => p.SupplierProducts)
                    .HasForeignKey(d => d.WebCompanyId)
                    .HasConstraintName("FK_supplierproducts_webcompanies");
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasKey(e => e.SupplierId);

                entity.Property(e => e.Address1).HasMaxLength(100);

                entity.Property(e => e.Address2).HasMaxLength(100);

                entity.Property(e => e.AddressCode).HasMaxLength(20);

                entity.Property(e => e.City).HasMaxLength(100);

                entity.Property(e => e.DateAdded)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.SupplierCode).HasMaxLength(50);

                entity.Property(e => e.TaxCode).HasMaxLength(40);

                entity.Property(e => e.Telephone).HasMaxLength(15);

                entity.HasOne(d => d.WebCompany)
                    .WithMany(p => p.Suppliers)
                    .HasForeignKey(d => d.WebCompanyId)
                    .HasConstraintName("FK_suppliers_webcompanies");
            });

            modelBuilder.Entity<WebCompanies>(entity =>
            {
                entity.HasKey(e => e.WebCompanyId);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateAdded)
                    .HasColumnType("smalldatetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.TheHash)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(20);
            });
        }
    }
}
