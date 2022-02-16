using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface IProductRepository
    {
        ///data access code
        ///CRUD
        IEnumerable<Product> GetAll();
        ActionResult<Product> GetById(int id);
        Product Add(Product newProduct);
    }

    public class ProductRepository : IProductRepository
    {
        private readonly StoreContext context;

        public ProductRepository(StoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public IEnumerable<Product> FindByCategory(int categoryId)
        {
            return context.Products.Where(x => x.Categoryid == categoryId).ToList();
        }
        public ActionResult<Product> GetById(int id)
        {
            try
            {
                var result = context.Products.Where(x => x.Productid == id).First();
                return result;
            }
            catch (ArgumentNullException ex)
            {
                return null;
            }
        }
        public Product Add(Product newProduct)
        {
            var addedProduct = context.Products.Add(newProduct);
            context.SaveChanges();
            return addedProduct.Entity;
        }
    }
}
