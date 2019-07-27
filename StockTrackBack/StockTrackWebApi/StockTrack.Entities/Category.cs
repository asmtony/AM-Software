using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockTrack.Entities
{
    [Table("Categorys")]
    public partial class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
