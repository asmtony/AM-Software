using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrack.Entities
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [StringLength(15)]
        public string Telephone { get; set; }

        [StringLength(100)]
        public string Address1 { get; set; }

        [StringLength(100)]
        public string Address2 { get; set; }

        [StringLength(100)]
        public string City { get; set; }

        [StringLength(20)]
        public string AddressCode { get; set; }

        [StringLength(40)]
        public string TaxCode { get; set; }

        public int WebCompanyId { get; set; }

        public virtual WebCompany WebCompany { get; set; }
    }
}

