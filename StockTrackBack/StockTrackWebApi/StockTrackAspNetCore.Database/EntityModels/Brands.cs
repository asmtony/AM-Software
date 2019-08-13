using System;
using System.Collections.Generic;

namespace StockTrackAspNetCore.Database.EntityModels
{
    public partial class Brands
    {
        public long BrandId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long WebCompanyId { get; set; }
        public DateTime DateAdded { get; set; }

        public virtual WebCompanies WebCompany { get; set; }
    }
}
