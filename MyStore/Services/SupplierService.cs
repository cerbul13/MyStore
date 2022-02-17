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

    public interface ISupplierService
    {
        SupplierModel AddSupplier(SupplierModel newSupplier);
        IEnumerable<SupplierModel> GetAllSuppliers();
        ActionResult<SupplierModel> GetById(int id);
    }

    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository supplierRepository;
        private readonly IMapper mapper;

        public SupplierService(ISupplierRepository supplierRepository, IMapper mapper)
        {
            this.supplierRepository = supplierRepository;
            this.mapper = mapper;
        }

        public IEnumerable<SupplierModel> GetAllSuppliers()
        {
            var allSuppliers = supplierRepository.GetAll().ToList();//List<Product>
                                                                    //transform domain objects from List<Product> -> List<ProductModel>
            var supplierModels = mapper.Map<IEnumerable<SupplierModel>>(allSuppliers);

            return supplierModels;
        }

        public ActionResult<SupplierModel> GetById(int id)
        {
            var supplierToGet = supplierRepository.GetById(id);
            return mapper.Map<SupplierModel>(supplierToGet);
        }
        public SupplierModel AddSupplier(SupplierModel newSupplier)
        {
            //Product addedProduct = mapper.Map<Product>(newProduct);
            //return productRepository.Add(addedProduct);

            Supplier supplierToAdd = mapper.Map<Supplier>(newSupplier);
            var addedSupplier = supplierRepository.Add(supplierToAdd);
            newSupplier = mapper.Map<SupplierModel>(addedSupplier);
            return newSupplier;
        }
    }
}
