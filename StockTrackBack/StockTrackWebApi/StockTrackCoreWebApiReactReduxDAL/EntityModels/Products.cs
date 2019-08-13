using System;
using System.Collections.Generic;

namespace StockTrackCoreWebApiReactReduxDAL.EntityModels
{
    public partial class Products
    {
        public Products()
        {
            SupplierProducts = new HashSet<SupplierProducts>();
        }

        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PackSize { get; set; }
        public string TaxCode { get; set; }
        public int WebCompanyId { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual WebCompanies WebCompany { get; set; }
        public virtual ICollection<SupplierProducts> SupplierProducts { get; set; }
    }
}
