using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface ISupplierRepository
    {
        Supplier Add(Supplier newSupplier);

        ///data access code
        ///CRUD
        IEnumerable<Supplier> GetAll();
        ActionResult<Supplier> GetById(int id);
    }

    public class SupplierRepository : ISupplierRepository
    {
        private readonly StoreContext context;

        public SupplierRepository(StoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<Supplier> GetAll()
        {
            return context.Suppliers.ToList();
        }

        //public IEnumerable<Supplier> FindByCategory(int categoryId)
        //{
        //    return context.Suppliers.Where(x => x. == categoryId).ToList();
        //}
        public ActionResult<Supplier> GetById(int id)
        {
            try
            {
                var result = context.Suppliers.Where(x => x.Supplierid == id).First();
                return result;
            }
            catch (ArgumentNullException ex)
            {
                return null;
            }
        }
        public Supplier Add(Supplier newSupplier)
        {
            var addedSupplier = context.Suppliers.Add(newSupplier);
            context.SaveChanges();
            return addedSupplier.Entity;
        }
    }
}
