using Microsoft.AspNetCore.Mvc;
using MyStore.Data;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Services
{

    public interface ISupplierService
    {
        IEnumerable<Supplier> GetAllSuppliers();
        ActionResult<Supplier> GetById(int id);
    }

    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;

        public SupplierService(ISupplierRepository supplierRepository)
        {
            this.supplierRepository = supplierRepository;
        }

        public IEnumerable<Supplier> GetAllSuppliers()
        {
            return supplierRepository.GetAll();
        }

        public ActionResult<Supplier> GetById(int id)
        {
            return supplierRepository.GetById(id);
        }
    }
}
