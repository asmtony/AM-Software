using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace StockTrackAspNetCore.Database.EntityModels
{
    public partial class Suppliers
    {
        public Suppliers()
        {
            SupplierProducts = new HashSet<SupplierProducts>();
        }
       
        public long SupplierId { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(50)]
        public string SupplierCode { get; set; }
        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(15)]
        public string Telephone { get; set; }

        [StringLength(100)]
        public string Address1 { get; set; }
        public string Address2 { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(20)]
        public string AddressCode { get; set; }
        public string TaxCode { get; set; }
        public long WebCompanyId { get; set; }

        public DateTime DateAdded { get; set; }

        public virtual WebCompanies WebCompany { get; set; }
        public virtual ICollection<SupplierProducts> SupplierProducts { get; set; }
    }
}
