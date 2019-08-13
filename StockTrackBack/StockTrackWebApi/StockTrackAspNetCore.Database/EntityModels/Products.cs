using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StockTrackAspNetCore.Database.EntityModels
{
    [Table("Products")]
    public partial class Product
    {
        public Product()
        {
            SupplierProducts = new HashSet<SupplierProducts>();
        }

        public long ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(20)]
        public string PackSize { get; set; }
        public string ProductCode { get; set; }

        public string ProductCodeOther { get; set; }
        public string Barcode { get; set; }
        public long WebCompanyId { get; set; }
        public DateTime DateAdded { get; set; }
        public decimal Price { get; set; }

        public virtual WebCompanies WebCompany { get; set; }
        public virtual ICollection<SupplierProducts> SupplierProducts { get; set; }
    }
}
