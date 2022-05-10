using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using MyStore.Data;
using MyStore.Domain.Entities;
using Xunit;
using 

namespace MyStore.Tests
{
    public class ProductRepositoryTests
    {
        public ProductRepositoryTests()
        {

        }

        [Fact]
        public void Should_GetAllProducts()
        {
            //arrange
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.GetAll())    //setup => ii zic ce sa returneze si din ce
                    .Returns(ReturnMultiple());

            //act
            var result = mockRepo.Object.GetAll();   //instanta dummy pe care si-o face el si de pe care pot apela metode care sunt in repository-ul meu

            //assert
            Assert.Equal(3, result.Count());

            Assert.IsType<List<Product>>(result);
        }

        [Fact]
        public void Should_GetOneProduct()
        {
            //arrange
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.GetById(ReturnMultiple()[0].Productid))
                .Returns(ReturnMultiple()[0]);

            //act
            var result = mockRepo.Object.GetById(Consts.TestProduct);

            //asert
            Assert.Equal(Consts.TestProduct, result.Productid);
            Assert.IsType<Product>(result);
        }

        [Fact]
        public void Shoul_Return_Product_On_Post()
        {
            //arrange
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.Add(It.IsAny<Product>())).Returns(ReturnOneProduct(Consts.TestProduct));

            //act
            var result = mockRepo.Object.Add(ReturnOneProduct(Consts.TestProduct));

            //asert
            Assert.Equal(Consts.ProductName, result.Productname);
            Assert.IsType<Product>(result);
        }

        [Fact]
        public void ShouldReturn_Product_On_Put()
        {
            //arrange
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.Update(It.IsAny<Product>()));

            //act
            var result = mockRepo.Object.Update(ReturnOneProduct(Consts.TestProduct));

            //asert
            Assert.Equal(Consts.ProductName, result.Productname);
            Assert.IsType<Product>(result);
        }

        [Fact]
        public void Shoul_Return_True_On_Delete()
        {
            //arrange
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.Delete(It.IsAny<Product>())).Returns(true);

            //act
            var result = mockRepo.Object.Delete(ReturnOneProduct(Consts.TestProduct));

            //asert
            Assert.True(result);
        }

        private Product ReturnOneProduct(int i)
        {
            IEnumerable<Product> products = ReturnMultiple();
            return products.Where(x => x.Productid == i).FirstOrDefault();
        }
        private List<Product> ReturnMultiple()
        {
            return new List<Product>()
                            {
                                new Product{
                                    Productid=Consts.TestProduct,
                                    Categoryid=1,
                                    Productname="test",
                                    Supplierid=2,
                                    Unitprice=10,
                                    Discontinued=true
                                },
                                new Product{
                                    Productid=Consts.TestProduct+1,
                                    Categoryid=2,
                                    Productname="test2",
                                    Supplierid=3,
                                    Unitprice=100,
                                    Discontinued=true
                                },
                                new Product{
                                    Productid=Consts.TestProduct+2,
                                    Categoryid=3,
                                    Productname="test3",
                                    Supplierid=3,
                                    Unitprice=100,
                                    Discontinued=true
                                }
                            };
        }
        //private List<Product> ReturnMultiple()
        //{
        //    return new List<Product>()
        //    {
        //        new Product
        //        {
        //            Productid = ProductConsts.TestProduct,
        //            Productname = ProductConsts.ProductName,
        //            Categoryid = (int)ProductConsts.Categories.Condiments,
        //            Supplierid = ProductConsts.TestSupplierId,
        //            Unitprice = ProductConsts.TestUnitPrice,
        //            Discontinued = true
        //        },
        //        new Product
        //        {
        //            Productid = ProductConsts.TestProduct2,
        //            Productname = ProductConsts.ProductName2,
        //            Categoryid = (int)ProductConsts.Categories.Confections,
        //            Supplierid = ProductConsts.TestSupplierId2,
        //            Unitprice = ProductConsts.TestUnitPrice,
        //            Discontinued = true
        //        },
        //        new Product
        //        {
        //            Productid = ProductConsts.TestProduct3,
        //            Productname = ProductConsts.ProductName3,
        //            Categoryid = (int)ProductConsts.Categories.Dairy,
        //            Supplierid = ProductConsts.TestSupplierId3,
        //            Unitprice = ProductConsts.TestUnitPrice,
        //            Discontinued = true
        //        }
        //    };
        //}
    }
}




//using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.Extensions.Hosting;
//using Moq;
//using MyStore.Data;
//using MyStore.Domain.Entities;
//using MyStore.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Xunit;

//namespace MyStore.Tests
//{
//    public class ProductRepositoryTests//DbContext//IStoreContext
//    {
//        public Mock<StoreContext> mockStoreContext;
//        public Mock<DbSet<Product>> mockContext;
//        public static IServiceProvider ServiceProvider { get; private set; }
//        public ProductRepositoryTests()
//        {
//            mockStoreContext = new Mock<StoreContext>();
//            mockContext = new Mock<DbSet<Product>>();
//            //var serviceCollection = new Microsoft.Extensions.DependencyInjection.ServiceCollection();
//            //   this.Products = new TestProductDbSet();
//        }
//        //public DbSet<Product> Products { get; set; }

//        //public int SaveChanges()
//        //{
//        //    return 0;
//        //}

//        //public void MarkAsModified(Product item) { }
//        //public void Dispose() { }
//        //[Fact]
//        //public void Should_GetAllProducts()
//        //{
//        //    //arrange
//        //    var mockRepo = new Mock<IProductRepository>();
//        //    //mockRepo.Object.toate metodele din interfata
//        //    mockRepo.Setup(repo => repo.GetAll())
//        //            .Returns(ReturnMultiple());
//        //    //act
//        //    var result = mockRepo.Object.GetAll();
//        //    //assert
//        //    Assert.Equal(2, result.Count());
//        //    Assert.IsType<List<Product>>(result);
//        //}
//        [Fact]
//        public void Should_GetAllProducts()
//        {
//            //arrange
//            //mockStoreContext.Setup(repo => repo.Products.ToList()).Returns(ReturnMultiple());
//            //mockStoreContext.Setup(repo => repo.Products.ToList()).Returns(ReturnMultiple());
//            var productMock = new Mock<DbSet<Product>>();
//            mockStoreContext.Setup(repo => repo.Products).Returns(productMock.Object);
//            //mockStoreContext.Setup(repo => repo.Set<Product>()).Returns(productMock.Object);
//            //mockStoreContext.Setup(repo => repo.Products.ToList()).Returns(ReturnMultiple());
//            //mockStoreContext.Setup(repo => repo.Products.ToList()).Returns<IEnumerable<Product>>(repo=>repo.ToList());
//            //act
//            var repository = new ProductRepository(mockStoreContext.Object);
//            //var repository = new ProductRepository(storeContext);
//            var result = repository.GetAll();
//            //assert
//            Assert.Equal(2, result.Count());
//            Assert.IsType<List<Product>>(result);
//        }
//        private List<Product> ReturnMultiple()
//        {
//            return new List<Product>()
//                    {
//                        new Product{
//                            Categoryid=1,
//                            Productname="test",
//                            Supplierid=2,
//                            Unitprice=10,
//                            Discontinued=true
//                        },
//                        new Product{
//                            Categoryid=2,
//                            Productname="test2",
//                            Supplierid=3,
//                            Unitprice=100,
//                            Discontinued=true
//                    }
//                    };
//        }
//    }
//}
