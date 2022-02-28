using Microsoft.EntityFrameworkCore;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Data
{
    public interface IOrderRepository
    {
        IQueryable<Order> GetAll(string shipCountry/*, List<string> shipCities*/);
        IQueryable<Order> GetAll(List<string> shipCities);
    }

    public class OrderRepository : IOrderRepository
    {
        private readonly StoreContext context;
        public OrderRepository(StoreContext context)
        {
            this.context = context;
        }
        public IQueryable<Order> GetAll(string shipCountry/*, List<string> shipCities*/)
        {
            var query = this.context.Orders.Include(x => x.Cust).Select(x=>x);

            if (!string.IsNullOrEmpty(shipCountry)) //de facut tema si list de shipCity
                                                    //select * from Orders where shipcity  in ('Warszawa', 'Reims')
            {
                query = query.Where(x => x.Shipcountry == shipCountry);
            }

            return query;
        }
        public IQueryable<Order> GetAll(List<string> shipCities)
        {
            var query = this.context.Orders.Include(x => x.Cust).Select(x => x);

            if (shipCities.Count!=0) //de facut tema si list de shipCity
                                                    //select * from Orders where shipcity  in ('Warszawa', 'Reims')
            {
                query = query.Where(x => shipCities.Contains(x.Shipcity));
            }

            return query;
        }
    }
}
