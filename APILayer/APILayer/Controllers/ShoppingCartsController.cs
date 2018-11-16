using System;
using System.Collections.Generic;
using APILayer.Models;
using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingCartsController : ControllerBase
    {
        private readonly IShoppingCartRepository _repository;

        public ShoppingCartsController(IShoppingCartRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IReadOnlyList<ShoppingCartModel>> Get()
        {
            return Ok(this._repository.GetAll());
        }

        [HttpGet("{shoppingCartId}", Name = "GetById")]
        public ActionResult<ShoppingCart> GetById(Guid shoppingCartId)
        {
            return Ok(this._repository.GetById(shoppingCartId));
        }

        [HttpPost]
        public ActionResult<ShoppingCart> Post([FromBody] ShoppingCartModel shoppingCartModel)
        {
            if (shoppingCartModel == null)
            {
                return BadRequest();
            }


            ShoppingCart shoppingCart = new ShoppingCart(shoppingCartModel.Date, shoppingCartModel.Description);
            this._repository.Create(shoppingCart);
            this._repository.SaveChanges();

            return CreatedAtRoute("GetById", new { id = shoppingCart.Id }, shoppingCart);
        }

        [Route("{shoppingCartId}/products/{productId}")]
        [HttpGet]
        public ActionResult<Product> GetProductByShoppingCart(Guid shoppingCartId, Guid productId)
        {
            return Ok(_repository.GetProductByShoppingCart(shoppingCartId, productId));
        }
    }
}