using StockTrack.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StockTrackWebApi.Repositories
{
    public class ProductsContext : DbContext
    {
        public ProductsContext()
           : base("name=StockTrack")
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categorys { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<WebCompany> WebCompanies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .IsUnicode(false);
        }
    }
}