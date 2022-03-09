using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Tests
{
    public static class Consts
    {
        public static int CategoryId = 2;
        public static int TestProduct = 3;
        public static int TestSupplierId = 4;
        public static decimal TestUnitPrice = 3.5M;
        public const string ProductName = "Test Product Name 1";
        public enum Categories
        {
            Condiments=2,
            Confections=3,
            Dairy=4,
            Grains=5,
            Meat=6           
        }
    }
}
