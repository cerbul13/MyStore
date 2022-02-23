﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Domain.Entities;
using MyStore.Models;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<ProductModel> Get()
        {
            var productList = productService.GetAllProducts();
            return productList;
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id:int}")]
        public ActionResult<ProductModel> GetProduct(int id)
        {
            var result = productService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post([FromBody] ProductModel newProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //failfast -> return
            //productService.Add();
            var addedProduct = productService.AddProduct(newProduct);
            
            return CreatedAtAction("Get", new { id = addedProduct.Productid }, addedProduct);
            //return CreatedAtAction("Get", newProduct,new { id = newProduct.Productid });
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)] //,Type=typeof(Product) daca vreau sa adaug obiectul la return
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type=typeof(ProductModel))]
        [Consumes(MediaTypeNames.Application.Json)]
        public IActionResult Put(int id, [FromBody] ProductModel productToUpdate)
        {
            //exists by 
            if (id!=productToUpdate.Productid)
            {
                return BadRequest();
            }
            if (!productService.Exists(id))
            {
                return NotFound();
            }
            productService.UpdateProduct(productToUpdate);
            return NoContent();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!productService.Exists(id))
            {
                return NotFound();
            }
            productService.Delete(id);
            return NoContent();
            //search the object with the id
            //delete the object
            //return no content
        }
    }
}
