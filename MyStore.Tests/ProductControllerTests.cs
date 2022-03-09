using Microsoft.AspNetCore.Mvc;
using Moq;
using MyStore.Controllers;
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
                Productid = Consts.TestProduct,
                Productname = Consts.ProductName,
                Discontinued = false,
                Supplierid=Consts.TestSupplierId,
                Unitprice=Consts.TestUnitPrice
            },
            new ProductModel
            {
                Categoryid = (int)Consts.Categories.Condiments,
                Productid = Consts.TestProduct,
                Productname = Consts.ProductName,
                Discontinued = false,
                Supplierid=Consts.TestSupplierId,
                Unitprice=Consts.TestUnitPrice
            },
            };
        }
    }
}
