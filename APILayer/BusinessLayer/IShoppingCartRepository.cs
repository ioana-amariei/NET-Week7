using System;
using System.Collections.Generic;
using DataLayer;

namespace BusinessLayer
{
    public interface IShoppingCartRepository
    {
        void Create(ShoppingCart shoppingCart);
        void Update(ShoppingCart shoppingCart);
        void Delete(Guid id);
        ShoppingCart GeById(Guid id);
        IReadOnlyList<ShoppingCart> GetAll();
        void SaveChanges();
        bool Exists(Guid id);
    }
}