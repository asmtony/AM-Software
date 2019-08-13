using System;
using System.Collections.Generic;
using System.Text;

namespace StockTrackCoreWebApiReactReduxDLL.Model
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PackSize { get; set; }
        public string TaxCode { get; set; }
        public int WebCompanyId { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
