using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface ICustomerRepository
    {
        ///data access code
        ///CRUD
        IEnumerable<Customer> GetAll();
        ActionResult<Customer> GetById(int id);
    }

    public class CustomerRepository : ICustomerRepository
    {
        private readonly StoreContext context;

        public CustomerRepository(StoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<Customer> GetAll()
        {
            return context.Customers.ToList();
        }

        //public IEnumerable<Customer> FindByCategory(int categoryId)
        //{
        //    return context.Customers.Where(x => x.Categoryid == categoryId).ToList();
        //}
        public ActionResult<Customer> GetById(int id)
        {
            try
            {
                var result = context.Customers.Where(x => x.Custid == id).First();
                return result;
            }
            catch (ArgumentNullException ex)
            {
                return null;
            }
        }
    }
}
