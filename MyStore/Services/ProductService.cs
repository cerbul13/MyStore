using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Services
{

    public interface IProductService
    {
        ProductModel AddProduct(ProductModel newProduct);
        bool Delete(int id);
        bool Exists(int id);
        IEnumerable<ProductModel> GetAllProducts();
        ProductModel GetById(int id);
        void UpdateProduct(ProductModel model);
    }

    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {
            //take domain objects
            var allProducts = productRepository.GetAll().ToList();//List<Product>
                                                                  //transform domain objects from List<Product> -> List<ProductModel>
            var productModels = mapper.Map<IEnumerable<ProductModel>>(allProducts);

            return productModels;
            //for (int i = 0; i < allProducts.Count(); i++)
            //{
            //    var productModel = new ProductModel();
            //    productModel.Categoryid = allProducts[i].Categoryid;
            //    productModel.Productid = allProducts[i].Productid;
            //    productModel.Productname = allProducts[i].Productname;
            //    productModel.Unitprice = allProducts[i].Unitprice;
            //    productModel.Discontinued = allProducts[i].Discontinued;
            //}

            //1 la 1
            //var source = new Product();
            //var destination = new ProductModel();

            //destination.Categoryid = source.Categoryid;
            //destination.Discontinued = source.Discontinued;
            //destination.Productid = source.Productid;
            //destination.Productname = source.Productname;
            //destination.Supplierid = source.Supplierid;
            //destination.Unitprice = source.Unitprice;



        }

        public ProductModel GetById(int id)
        {
            var productToGet=productRepository.GetById(id);
            return mapper.Map<ProductModel>(productToGet);
        }
        public bool Exists(int id)
        {
            return productRepository.Exists(id);
        }
        public ProductModel AddProduct(ProductModel newProduct)
        {
            //Product addedProduct = mapper.Map<Product>(newProduct);
            //return productRepository.Add(addedProduct);

            Product productToAdd = mapper.Map<Product>(newProduct);
            productRepository.Add(productToAdd);
            //var addedProduct = productRepository.Add(productToAdd);
            //newProduct = mapper.Map<ProductModel>(addedProduct);
            return newProduct;
        }
        public void UpdateProduct(ProductModel model)
        {
            Product productToUpdate = mapper.Map<Product>(model);
            productRepository.Update(productToUpdate);
        }
        public bool Delete(int id)
        {
            Product itemToDelete = productRepository.GetById(id);
            return productRepository.Delete(itemToDelete);
        }
    }
}
