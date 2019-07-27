using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrack.Entities
{
    public partial class Brand
    {
        public int BrandId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        public int WebCompanyId { get; set; }

        public virtual WebCompany WebCompany { get; set; }
    }
}
