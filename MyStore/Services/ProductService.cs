using Microsoft.AspNetCore.Mvc;
using MyStore.Data;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Services
{

    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        ActionResult<Product> GetById(int id);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return productRepository.GetAll();
        }

        public ActionResult<Product> GetById(int id)
        {
            return productRepository.GetById(id);
        }
    }
}
