using System;
using System.Collections.Generic;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace BusinessLayer
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Create(Product product)
        {
            _context.products.Add(product);
        }

        public void Update(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            Product product = _context.products.First(p => p.Id == id);
            _context.products.Remove(product);
        }

        public Product GetById(Guid id)
        {
            return _context.products.First(p => p.Id == id);
        }

        public IReadOnlyList<Product> GetAll()
        {
            return _context.products.ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public bool Exists(Guid id)
        {
            return _context.products.Any(p => p.Id == id);
        }
    }
}
