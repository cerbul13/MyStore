using Moq;
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
        public ProductServiceTests()
        {

        }
        [Fact]
        public void Should_GetAllProducts()
        {
            //arrange
            var mockRepo = new Mock<IProductService>();
            //mockRepo.Object.toate metodele din interfata
            mockRepo.Setup(repo => repo.GetAllProducts())
                    .Returns(ReturnMultiple());
            //act
            var result = mockRepo.Object.GetAllProducts();
            //assert
            Assert.Equal(2, result.Count());
            Assert.IsType<List<ProductModel>>(result);
        }
        private List<ProductModel> ReturnMultiple()
        {
            return new List<ProductModel>()
                    {
                        new ProductModel{
                            Productid=1,
                            Categoryid=1,
                            Productname="test",
                            Supplierid=2,
                            Unitprice=10,
                            Discontinued=true
                        },
                        new ProductModel{
                            Productid=2,
                            Categoryid=2,
                            Productname="test2",
                            Supplierid=3,
                            Unitprice=100,
                            Discontinued=true
                    }
                    };
        }
    }
}
