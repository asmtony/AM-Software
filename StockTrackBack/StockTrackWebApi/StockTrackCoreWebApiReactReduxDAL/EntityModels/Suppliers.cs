using System;
using System.Collections.Generic;

namespace StockTrackCoreWebApiReactReduxDAL.EntityModels
{
    public partial class Suppliers
    {
        public Suppliers()
        {
            SupplierProducts = new HashSet<SupplierProducts>();
        }

        public int SupplierId { get; set; }
        public string Name { get; set; }
        public string SupplierCode { get; set; }
        public string Description { get; set; }
        public string Telephone { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string AddressCode { get; set; }
        public string TaxCode { get; set; }
        public int WebCompanyId { get; set; }

        public virtual WebCompanies WebCompany { get; set; }
        public virtual ICollection<SupplierProducts> SupplierProducts { get; set; }
    }
}
