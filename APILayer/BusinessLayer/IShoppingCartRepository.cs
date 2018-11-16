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
        ShoppingCart GetById(Guid id);
        IReadOnlyList<ShoppingCart> GetAll();
        Product GetProductByShoppingCart(Guid shoppingCartId, Guid productId);
        void SaveChanges();
        bool Exists(Guid id);
    }
}