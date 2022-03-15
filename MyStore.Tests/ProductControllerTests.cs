﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MyStore.Controllers;
using MyStore.Models;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyStore.Tests
{
    public class ProductControllerTests
    {
        private Mock<IProductService> mockProductService;

        public ProductControllerTests()
        {
            mockProductService = new Mock<IProductService>();
        }
        [Fact]
        public void Should_Return_OK_OnGetAll()
        {
           //arrange
            mockProductService.Setup(x => x.GetAllProducts())
                .Returns(MultipleProducts());
            var controller = new ProductsController(mockProductService.Object);
            //act
            var response = controller.Get();
            var result = response.Result as OkObjectResult;
            var actualData = result.Value as IEnumerable<ProductModel>;
            //assert
            Assert.IsType<OkObjectResult>(result);
            Assert.IsType<List<ProductModel>>(actualData);
            //Assert.Equal(OkObjectResult, result);
        }
        [Fact]
        public void ShouldReturn_AllProducts()
        {
            //arrange
            mockProductService.Setup(x => x.GetAllProducts())
                .Returns(MultipleProducts());
            var controller = new ProductsController(mockProductService.Object);
            //act
            var response = controller.Get();
            var result = response.Result as OkObjectResult;
            var actualData = result.Value as IEnumerable<ProductModel>;
            //assert
            Assert.Equal(MultipleProducts().Count(), actualData.Count());
        }
        //public void ShouldReturn_NoContent_On_Post()  //Manuela
        //{

        //    mockProductService.Setup(x => x.AddProduct(It.IsAny<ProductModel>())).Returns(ProductToInsert());
        //    var controller = new ProductsController(mockProductService.Object);
        //    //act
        //    var response = controller.Post(ProductToInsert());
        //    var result = response.Result as CreatedAtActionResult;
        //    var actualData = result.Value as ProductModel;
        //    //assert
        //    Assert.IsType<CreatedAtActionResult>(result);
        //    Assert.IsType<ProductModel>(actualData);
        //}
        [Fact]
        public void ShouldReturn_NoContent_On_Post()
        {
            ////arrange       
            mockProductService.Setup(x => x.AddProduct(MultipleProducts()[1])).Returns(MultipleProducts()[1]);
            //mockProductService.Setup(x => x.AddProduct(It.IsAny<ProductModel>())).Returns(MultipleProducts()[1]);
            // Arrange
            var controller = new ProductsController(mockProductService.Object);
            // Act
            var response = controller.Post(MultipleProducts()[1]);
            // Assert
            Assert.IsType<CreatedAtActionResult>(response);
        }

        [Fact]
        public void ShouldReturn_NoContent_On_Put()
        {
            ////arrange       
            mockProductService.Setup(x => x.UpdateProduct(MultipleProducts()[1]));//.Returns(true);//.Returns(Ok(MutipleProducts()[2]));
            mockProductService.Setup(x => x.Exists(MultipleProducts()[1].Productid)).Returns(true);//.Returns(true);//.Returns(Ok(MutipleProducts()[2]));
            // Arrange
            var controller = new ProductsController(mockProductService.Object);
            // Act
            var response = controller.Put(MultipleProducts()[1].Productid,MultipleProducts()[1]);
            // Assert
            Assert.IsType<NoContentResult>(response);
        }
        [Fact]
        public void ShouldReturn_NoContent_On_Delete()
        {
            ////arrange                     
            mockProductService.Setup(x => x.Delete(MultipleProducts()[1].Productid)).Returns(true);//.Returns(Ok(MutipleProducts()[2]));
            mockProductService.Setup(x => x.Exists(MultipleProducts()[1].Productid)).Returns(true);//.Returns(true);//.Returns(Ok(MutipleProducts()[2]));
            // Arrange
            var controller = new ProductsController(mockProductService.Object);
            // Act
            var response = controller.Delete(MultipleProducts()[1].Productid);            
            // Assert
            Assert.IsType<NoContentResult>(response);            
        }
        //[Fact]
        //public void ShouldReturn_NoContent_On_Delete()
        //{
        //    ////arrange
        //    //mockProductService.Setup(x => x.Delete(It.IsAny<int>())).Returns(OkObjectResult);
        //    //// Arrange
        //    //var controller = new ProductsController(mockProductService.Object);
        //    //// Act
        //    //var response = controller.Delete(MultipleProducts()[2].Productid);
        //    //var result = response.Result as OkObjectResult;
        //    //var actualData = result.Value as ProductModel;
        //    //// Assert
        //    //Assert.IsType<OkObjectResult>(result);
        //    //Assert.IsType<ProductModel>(actualData);            

        //    mockProductService.Setup(x => x.Delete(It.IsAny<int>()));//.Returns(true);//.Returns(Ok(MutipleProducts()[2]));
        //    mockProductService.Setup(x => x.Exists(MultipleProducts()[1].Productid)).Returns(true);//.Returns(true);//.Returns(Ok(MutipleProducts()[2]));
        //    // Arrange
        //    var controller = new ProductsController(mockProductService.Object);
        //    // Act
        //    var response = controller.Delete(MultipleProducts()[1].Productid);
        //    //var result = response. as OkObjectResult;
        //    //var actualData = result.Value as ProductModel;
        //    // Assert
        //    Assert.IsType<NoContentResult>(response);
        //    //Assert.IsType<OkResult>(response);
        //    //Assert.IsType<NotFoundResult>(response);
        //    //Assert.IsType<ProductModel>(actualData);
        //}

        //public void ShouldReturn_NoContent_On_Delete()
        //{
        //    ////arrange
        //    mockProductService.Setup(x => x.Delete(MultipleProducts()[1].Productid)).Returns(true);
        //    mockProductService.Setup(x => x.Exists(MultipleProducts()[1].Productid)).Returns(true);
        //    // Arrange
        //    var controller = new ProductsController(mockProductService.Object);
        //    // Act
        //    var result = controller.Delete(MultipleProducts()[1].Productid);
        //    // Assert
        //    Assert.IsType<NoContentResult>(result);
        //}

        private List<ProductModel> MultipleProducts()
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
