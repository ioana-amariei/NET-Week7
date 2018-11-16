using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer
{
    public class ShoppingCart
    {
        private ShoppingCart()
        {
            //EF
        }
        public ShoppingCart(DateTime date, String description)
        {
            Id = new Guid();
            Date = date;
            Description = description;
            Products = new HashSet<Product>();
        }
        public Guid Id { get; private set; }

        public DateTime Date { get; private set; }
        public String Description { get; private set; }

        [NotMapped]
        public Decimal Total { get; private set; }
        public ICollection<Product> Products { get; private set; }
    }
}
