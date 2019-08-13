using System;
using System.Collections.Generic;

namespace StockTrackCoreWebApiReactReduxDAL.EntityModels
{
    public partial class Lookups
    {
        public int LookupId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public int WebCompanyId { get; set; }

        public virtual WebCompanies WebCompany { get; set; }
    }
}
