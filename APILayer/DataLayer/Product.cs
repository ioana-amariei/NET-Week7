using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    public class Product
    {
        private Product()
        {
            //EF
        }

        public Product(String name, Decimal price, int pieces)
        {
            Id = Guid.NewGuid();
            Name = name;
            Price = price;
            Pieces = pieces;
        }

        public Guid Id { get; private set; }
        public Guid ShoppingCartId { get; private set; }
        public String Name { get; private set; }
        public Decimal Price { get; private set; }
        public int Pieces { get; private set; }
        [NotMapped]
        public Decimal Total { get; private set; }
        public void AttachShoppingCart(Guid id)
        {
            this.ShoppingCartId = id;
        }
    }
}
