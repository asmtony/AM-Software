using System;
using System.Collections.Generic;

namespace StockTrackAspNetCore.Database.EntityModels
{
    public partial class SupplierProducts
    {
        public long SupplierProductId { get; set; }
        public long WebCompanyId { get; set; }
        public long ProductId { get; set; }
        public long SupplierId { get; set; }
        public string Description { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual Product Product { get; set; }
        public virtual Suppliers Supplier { get; set; }
        public virtual WebCompanies WebCompany { get; set; }
    }
}
