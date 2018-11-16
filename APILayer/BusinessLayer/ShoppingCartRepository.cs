using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ApplicationContext _context;

        public ShoppingCartRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(ShoppingCart shoppingCart)
        {
            _context.shoppingCarts.Add(shoppingCart);
        }

        public void Update(ShoppingCart shoppingCart)
        {
            _context.Entry(shoppingCart).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            ShoppingCart shoppingCart = _context.shoppingCarts.First(p => p.Id == id);
            _context.shoppingCarts.Remove(shoppingCart);
        }

        public ShoppingCart GetById(Guid id)
        {
            return _context.shoppingCarts.First(p => p.Id == id);
        }

        public IReadOnlyList<ShoppingCart> GetAll()
        {
            return _context.shoppingCarts.ToList();
        }

        public Product GetProductByShoppingCart(Guid shoppingCartId, Guid productId)
        {
            ShoppingCart shoppingCart = GetById(shoppingCartId);

            foreach (Product product in shoppingCart.Products)
            {
                if (product.Id == productId)
                {
                    return product;
                }
            }

            return null;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool Exists(Guid id)
        {
            return _context.shoppingCarts.Any(p => p.Id == id);
        }
    }
}