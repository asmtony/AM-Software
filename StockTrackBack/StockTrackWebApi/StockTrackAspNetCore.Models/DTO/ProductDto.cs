using System;
using System.Collections.Generic;
using System.Text;

namespace StockTrackAspNetCore.Models.DTO
{
    public class ProductDto
    {
        public long ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PackSize { get; set; }
        public string ProductCode { get; set; }
        public string ProductCodeOther { get; set; }
        public string Barcode { get; set; }
        public Int64 WebCompanyId { get; set; }
        public string CompanyName { get; set; }
        public DateTime DateAdded { get; set; }
        public decimal Price { get; set; }
    }
}
