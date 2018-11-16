using System;
using System.Collections.Generic;
using DataLayer;

namespace BusinessLayer
{
    public interface IProductRepository
    {
        void Create(Product product, Guid id);
        void Update(Product product);
        void Delete(Guid id);
        Product GetById(Guid id);
        IReadOnlyList<Product> GetAll();
        void SaveChanges();
        bool Exists(Guid id);
    }
}