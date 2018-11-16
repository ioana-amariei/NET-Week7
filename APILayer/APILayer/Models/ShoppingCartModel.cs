using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DataLayer;

namespace APILayer.Models
{
    public class ShoppingCartModel
    {
        public DateTime Date { get; set; }
        public String Description { get; set; }
        [NotMapped]
        public Decimal Total { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
