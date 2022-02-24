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
            var allOrders = orderRepository.GetAll("Poland").ToList();
            return allOrders;
        }
    }
}
