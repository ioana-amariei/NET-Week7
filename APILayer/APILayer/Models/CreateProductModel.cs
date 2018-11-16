using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APILayer.Models
{
    public class CreateProductModel
    {
        public String Name { get;  set; }
        public Decimal Price { get; set; }
        public int Pieces { get; set; }

        [NotMapped]
        public Decimal Total { get; set; }
    }
}
