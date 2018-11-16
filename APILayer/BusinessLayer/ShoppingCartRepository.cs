using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer
{
    public class ShoppingCardRepository
    {
        private readonly ApplicationContext _context;

        public ShoppingCardRepository(ApplicationContext context)
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

        public ShoppingCart GeById(Guid id)
        {
            return _context.shoppingCarts.First(p => p.Id == id);
        }

        public IReadOnlyList<ShoppingCart> GetAll()
        {
            return _context.shoppingCarts.ToList();
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
