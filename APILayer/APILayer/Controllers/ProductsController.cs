using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APILayer.Models;
using BusinessLayer;
using DataLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APILayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repository;

        public ProductsController(IProductRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{id}", Name = "GetByProductId")]
        public ActionResult<Product> GetById(Guid id)
        {
            if (_repository.Exists(id) == false)
            {
                return NotFound();
            }

            return Ok(_repository.GetById(id));
        }

        [HttpGet]
        public ActionResult<IReadOnlyList<Product>> Get()
        {
            return Ok(_repository.GetAll());
        }

        [HttpDelete("{id}")]
        public ActionResult<Product> Delete(Guid id)
        {
            if (_repository.Exists(id) == false)
            {
                return NotFound();
            }

            _repository.Delete(id);
            _repository.SaveChanges();

            return NoContent();
        }


        [HttpPost("{id}")]
        public ActionResult<Product> Create([FromBody] CreateProductModel createProductModel, Guid id)
        {
            if (createProductModel == null)
            {
                return BadRequest();
            }

            Product product = new Product(createProductModel.Name, createProductModel.Price, createProductModel.Pieces);
            _repository.Create(product, id);
            _repository.SaveChanges();

            return CreatedAtRoute("GetByProductId", new {id = product.Id}, product);
        }
    }
}