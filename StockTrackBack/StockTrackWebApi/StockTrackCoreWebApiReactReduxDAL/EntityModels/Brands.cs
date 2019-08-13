using System;
using System.Collections.Generic;

namespace StockTrackCoreWebApiReactReduxDAL.EntityModels
{
    public partial class Brands
    {
        public int BrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int WebCompanyId { get; set; }

        public virtual WebCompanies WebCompany { get; set; }
    }
}
