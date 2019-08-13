using System;
using System.Collections.Generic;

namespace StockTrackAspNetCore.Database.EntityModels
{
    public partial class WebCompanies
    {
        public WebCompanies()
        {
            Brands = new HashSet<Brands>();
            Lookups = new HashSet<Lookups>();
            Products = new HashSet<Product>();
            SupplierProducts = new HashSet<SupplierProducts>();
            Suppliers = new HashSet<Suppliers>();
        }

        public long WebCompanyId { get; set; }
        public string CompanyName { get; set; }
        public string UserName { get; set; }
        public string TheHash { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual ICollection<Brands> Brands { get; set; }
        public virtual ICollection<Lookups> Lookups { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<SupplierProducts> SupplierProducts { get; set; }
        public virtual ICollection<Suppliers> Suppliers { get; set; }
    }
}
