using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StockTrackCoreWebApiReactReduxDAL.EntityModels
{
    public partial class StockTrackContext : DbContext
    {
        public StockTrackContext()
        {
        }

        public StockTrackContext(DbContextOptions<StockTrackContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<Categorys> Categorys { get; set; }
        public virtual DbSet<Lookups> Lookups { get; set; }
        public virtual DbSet<Products> Products { get; set; }
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
                    .HasName("PK_dbo.Brands");

                entity.HasIndex(e => e.WebCompanyId)
                    .HasName("IX_WebCompanyId");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.WebCompany)
                    .WithMany(p => p.Brands)
                    .HasForeignKey(d => d.WebCompanyId)
                    .HasConstraintName("FK_dbo.Brands_dbo.WebCompanies_WebCompanyId");
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
                entity.HasKey(e => e.LookupId)
                    .HasName("PK_dbo.Lookups");

                entity.HasIndex(e => e.WebCompanyId)
                    .HasName("IX_WebCompanyId");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Key).HasMaxLength(100);

                entity.Property(e => e.Value).HasMaxLength(200);

                entity.HasOne(d => d.WebCompany)
                    .WithMany(p => p.Lookups)
                    .HasForeignKey(d => d.WebCompanyId)
                    .HasConstraintName("FK_dbo.Lookups_dbo.WebCompanies_WebCompanyId");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK_dbo.Products");

                entity.HasIndex(e => e.WebCompanyId)
                    .HasName("IX_WebCompanyId");

                entity.Property(e => e.DateAdded).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PackSize).HasMaxLength(20);

                entity.Property(e => e.TaxCode).HasMaxLength(40);

                entity.HasOne(d => d.WebCompany)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.WebCompanyId)
                    .HasConstraintName("FK_dbo.Products_dbo.WebCompanies_WebCompanyId");
            });

            modelBuilder.Entity<SupplierProducts>(entity =>
            {
                entity.HasKey(e => e.SupplierProductId)
                    .HasName("PK_dbo.SupplierProducts");

                entity.HasIndex(e => e.ProductId)
                    .HasName("IX_ProductId");

                entity.HasIndex(e => e.SupplierId)
                    .HasName("IX_SupplierId");

                entity.HasIndex(e => e.WebCompanyId)
                    .HasName("IX_WebCompanyId");

                entity.Property(e => e.Description).HasMaxLength(250);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SupplierProducts)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.SupplierProducts_dbo.Products_ProductId");

                entity.HasOne(d => d.Supplier)
                    .WithMany(p => p.SupplierProducts)
                    .HasForeignKey(d => d.SupplierId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_dbo.SupplierProducts_dbo.Suppliers_SupplierId");

                entity.HasOne(d => d.WebCompany)
                    .WithMany(p => p.SupplierProducts)
                    .HasForeignKey(d => d.WebCompanyId)
                    .HasConstraintName("FK_dbo.SupplierProducts_dbo.WebCompanies_WebCompanyId");
            });

            modelBuilder.Entity<Suppliers>(entity =>
            {
                entity.HasKey(e => e.SupplierId)
                    .HasName("PK_dbo.Suppliers");

                entity.HasIndex(e => e.WebCompanyId)
                    .HasName("IX_WebCompanyId");

                entity.Property(e => e.Address1).HasMaxLength(100);

                entity.Property(e => e.Address2).HasMaxLength(100);

                entity.Property(e => e.AddressCode).HasMaxLength(20);

                entity.Property(e => e.City).HasMaxLength(100);

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
                    .HasConstraintName("FK_dbo.Suppliers_dbo.WebCompanies_WebCompanyId");
            });

            modelBuilder.Entity<WebCompanies>(entity =>
            {
                entity.HasKey(e => e.WebCompanyId)
                    .HasName("PK_dbo.WebCompanies");

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasMaxLength(100);

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
