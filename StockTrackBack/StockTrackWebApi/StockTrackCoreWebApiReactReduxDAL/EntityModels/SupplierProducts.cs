using System;
using System.Collections.Generic;

namespace StockTrackCoreWebApiReactReduxDAL.EntityModels
{
    public partial class SupplierProducts
    {
        public int SupplierProductId { get; set; }
        public int WebCompanyId { get; set; }
        public int ProductId { get; set; }
        public int SupplierId { get; set; }
        public string Description { get; set; }

        public virtual Products Product { get; set; }
        public virtual Suppliers Supplier { get; set; }
        public virtual WebCompanies WebCompany { get; set; }
    }
}
