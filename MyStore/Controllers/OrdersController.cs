using Microsoft.AspNetCore.Mvc;
using MyStore.Domain.Entities;
using MyStore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;

        public OrdersController(IOrderService productService)
        {
            this.orderService = productService;
        }

        [HttpGet]

        public IEnumerable<Order> Get([FromQuery] List<string> listOfTowns)
        {
            var orderList = orderService.GetAll(listOfTowns);
            return orderList;
        }
        [HttpGet]
        [Route("GetOrdersByCountry/{country}")]
        public IEnumerable<Order> Get(string country)
        {
            var orderList = orderService.GetAll(country);
            return orderList;
        }


        //public IEnumerable<Order> Get([FromQuery] string[] listOfTowns, [FromQuery] string country)
        //{
        //    if (listOfTowns==null)
        //    {
        //        var orderList = orderService.GetAll(country);
        //        return orderList;
        //    } else
        //    {
        //        List<string> townsList = new List<string>();
        //        for (int i=0;i<listOfTowns.Length;i++)
        //        {
        //            townsList.Add(listOfTowns[i]);
        //        }
        //        var orderList = orderService.GetAll(townsList);
        //        return orderList;
        //    }
        //}


        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        //[Route("api/[controller]")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
