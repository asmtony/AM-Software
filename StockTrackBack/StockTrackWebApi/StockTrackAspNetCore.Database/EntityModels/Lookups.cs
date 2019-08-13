using System;
using System.Collections.Generic;

namespace StockTrackAspNetCore.Database.EntityModels
{
    public partial class Lookups
    {
        public long LookupId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public long WebCompanyId { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual WebCompanies WebCompany { get; set; }
    }
}
