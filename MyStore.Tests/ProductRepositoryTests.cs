using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Moq;
using MyStore.Data;
using MyStore.Domain.Entities;
using MyStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace MyStore.Tests
{
    public class ProductRepositoryTests//DbContext//IStoreContext
    {
        public Mock<StoreContext> mockStoreContext;
        public Mock<DbSet<Product>> mockContext;
        public static IServiceProvider ServiceProvider { get; private set; }
        public ProductRepositoryTests()
        {
            mockStoreContext = new Mock<StoreContext>();
            mockContext = new Mock<DbSet<Product>>();
            //var serviceCollection = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
            //   this.Products = new TestProductDbSet();
        }
        //public DbSet<Product> Products { get; set; }

        //public int SaveChanges()
        //{
        //    return 0;
        //}

        //public void MarkAsModified(Product item) { }
        //public void Dispose() { }
        //[Fact]
        //public void Should_GetAllProducts()
        //{
        //    //arrange
        //    var mockRepo = new Mock<IProductRepository>();
        //    //mockRepo.Object.toate metodele din interfata
        //    mockRepo.Setup(repo => repo.GetAll())
        //            .Returns(ReturnMultiple());
        //    //act
        //    var result = mockRepo.Object.GetAll();
        //    //assert
        //    Assert.Equal(2, result.Count());
        //    Assert.IsType<List<Product>>(result);
        //}
        [Fact]
        public void Should_GetAllProducts()
        {
            //arrange
            //mockStoreContext.Setup(repo => repo.Products.ToList()).Returns(ReturnMultiple());
            //mockStoreContext.Setup(repo => repo.Products.ToList()).Returns(ReturnMultiple());
            var productMock = new Mock<DbSet<Product>>();
            mockStoreContext.Setup(repo => repo.Products).Returns(productMock.Object);
            //mockStoreContext.Setup(repo => repo.Set<Product>()).Returns(productMock.Object);
            //mockStoreContext.Setup(repo => repo.Products.ToList()).Returns(ReturnMultiple());
            //mockStoreContext.Setup(repo => repo.Products.ToList()).Returns<IEnumerable<Product>>(repo=>repo.ToList());
            //act
            var repository = new ProductRepository(mockStoreContext.Object);
            //var repository = new ProductRepository(storeContext);
            var result = repository.GetAll();
            //assert
            Assert.Equal(2, result.Count());
            Assert.IsType<List<Product>>(result);
        }
        private List<Product> ReturnMultiple()
        {
            return new List<Product>()
                    {
                        new Product{
                            Categoryid=1,
                            Productname="test",
                            Supplierid=2,
                            Unitprice=10,
                            Discontinued=true
                        },
                        new Product{
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
