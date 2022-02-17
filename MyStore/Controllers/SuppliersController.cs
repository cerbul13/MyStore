using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyStore.Domain.Entities;
using MyStore.Models;
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
    public class SuppliersController : ControllerBase
    {
        private readonly ISupplierService supplierService;

        public SuppliersController(ISupplierService supplierService)
        {
            this.supplierService = supplierService;
        }

        // GET: api/<SuppliersController>
        [HttpGet]
        public IEnumerable<SupplierModel> Get()
        {
            var supplierList = supplierService.GetAllSuppliers();
            return supplierList;
        }

        // GET api/<SuppliersController>/5
        [HttpGet("{id:int}")]
        public ActionResult<Supplier> GetSupplier(int id)
        {
            var result = supplierService.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return result;
            }
        }

        // POST api/<SuppliersController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<SuppliersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<SuppliersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
