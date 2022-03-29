using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Models;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyStore.Tests
{
    public class ProductServiceTests
    {
        private Mock<IProductRepository> mockProductRepository;
        private Mock<IMapper> mockMapper;
        public ProductServiceTests()
        {
            mockProductRepository = new Mock<IProductRepository>();
            mockMapper = new Mock<IMapper>();
        }
        [Fact]
        public void Should_Return_Count_and_Type_OnGetAll()
        {
            //arrange
            mockProductRepository.Setup(x => x.GetAll())
                .Returns(MultipleProducts());
            var service = new ProductService(mockProductRepository.Object,mockMapper.Object);
            //act
            var response = service.GetAllProducts();
            //assert
            Assert.IsType<List<ProductModel>>(response);
            Assert.Equal(MultipleProducts().Count(), response.Count());
        }
        [Fact]
        public void ShouldReturn_Type_On_Post()
        {
            ////arrange       
            mockProductRepository.Setup(x => x.Add(MultipleProducts()[1])).Returns(MultipleProducts()[1]);
            //mockProductService.Setup(x => x.AddProduct(It.IsAny<ProductModel>())).Returns(MultipleProducts()[1]);
            // Arrange
            var service = new ProductService(mockProductRepository.Object,mockMapper.Object);
            // Act
            var response = service.AddProduct(MultipleProductsModel()[1]);
            // Assert
            Assert.IsType<ProductModel>(response);
            //Assert.IsType<CreatedAtActionResult>(response);
        }
        [Fact]
        public void ShouldReturn_true_On_Delete()
        {
            ////arrange                     
            mockProductRepository.Setup(x => x.Delete(MultipleProducts()[1])).Returns(true);//.Returns(Ok(MutipleProducts()[2]));
            // Arrange
            var service = new ProductService(mockProductRepository.Object,mockMapper.Object);
            // Act
            var response = service.Delete(MultipleProducts()[1].Productid);
            // Assert
            Assert.Equal(true,response);
        }
        private List<Product> MultipleProducts()
        {
            return new List<Product>() {
            new Product
            {
                Categoryid = (int)Consts.Categories.Condiments,
                Productid = Consts.TestProduct,
                Productname = Consts.ProductName,
                Discontinued = false,
                Supplierid=Consts.TestSupplierId,
                Unitprice=Consts.TestUnitPrice
            },
            new Product
            {
                Categoryid = (int)Consts.Categories.Condiments,
                Productid = Consts.TestProduct+1,
                Productname = Consts.ProductName,
                Discontinued = false,
                Supplierid=Consts.TestSupplierId,
                Unitprice=Consts.TestUnitPrice
            },
            new Product
            {
                Categoryid = (int)Consts.Categories.Condiments,
                Productid = Consts.TestProduct+2,
                Productname = Consts.ProductName,
                Discontinued = false,
                Supplierid=Consts.TestSupplierId,
                Unitprice=Consts.TestUnitPrice
            },
            };
        }
        private List<ProductModel> MultipleProductsModel()
        {
            return new List<ProductModel>() {
            new ProductModel
            {
                Categoryid = (int)Consts.Categories.Condiments,
                Productid = Consts.TestProduct,
                Productname = Consts.ProductName,
                Discontinued = false,
                Supplierid=Consts.TestSupplierId,
                Unitprice=Consts.TestUnitPrice
            },
            new ProductModel
            {
                Categoryid = (int)Consts.Categories.Condiments,
                Productid = Consts.TestProduct+1,
                Productname = Consts.ProductName,
                Discontinued = false,
                Supplierid=Consts.TestSupplierId,
                Unitprice=Consts.TestUnitPrice
            },
            new ProductModel
            {
                Categoryid = (int)Consts.Categories.Condiments,
                Productid = Consts.TestProduct+2,
                Productname = Consts.ProductName,
                Discontinued = false,
                Supplierid=Consts.TestSupplierId,
                Unitprice=Consts.TestUnitPrice
            },
            };
        }
    }
}
