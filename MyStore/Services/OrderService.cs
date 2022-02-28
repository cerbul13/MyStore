using AutoMapper;
using MyStore.Data;
using MyStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyStore.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll(string shipCountry);
        IEnumerable<Order> GetAll(List<string> shipCities);
    }

    public class OrderService : IOrderService
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMapper mapper;
        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            this.orderRepository = orderRepository;
            this.mapper = mapper;

        }
        public IEnumerable<Order> GetAll(string shipCountry)
        {
            var allOrders = orderRepository.GetAll(shipCountry).ToList();
            return allOrders;
        }
        public IEnumerable<Order> GetAll(List<string> shipCities)
        {
            var allOrders = orderRepository.GetAll(shipCities);
            return allOrders;
        }
    }
}
