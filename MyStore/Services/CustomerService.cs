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

    public interface ICustomerService
    {
        CustomerModel AddCustomer(CustomerModel newCustomer);
        IEnumerable<CustomerModel> GetAllCustomers();
        ActionResult<CustomerModel> GetById(int id);
    }

    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IMapper mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.mapper = mapper;
        }

        public IEnumerable<CustomerModel> GetAllCustomers()
        {
            //return customerRepository.GetAll();
            var allCustomers = customerRepository.GetAll().ToList();//List<Product>
                                                                  //transform domain objects from List<Product> -> List<ProductModel>
            var customerModels = mapper.Map<IEnumerable<CustomerModel>>(allCustomers);

            return customerModels;
        }

        public ActionResult<CustomerModel> GetById(int id)
        {
            var customerToGet = customerRepository.GetById(id);
            return mapper.Map<CustomerModel>(customerToGet);
        }
        public CustomerModel AddCustomer(CustomerModel newCustomer)
        {
            //Product addedProduct = mapper.Map<Product>(newProduct);
            //return productRepository.Add(addedProduct);

            Customer customerToAdd = mapper.Map<Customer>(newCustomer);
            var addedCustomer = customerRepository.Add(customerToAdd);
            newCustomer = mapper.Map<CustomerModel>(addedCustomer);
            return newCustomer;
        }
    }
}
