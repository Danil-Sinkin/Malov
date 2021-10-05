using ConsoleApp1.Enums;
using ConsoleApp1.Models;
using ConsoleApp1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class OrderService : IOrderService
    {      
        public static List<OrderModel> Orders = new List<OrderModel>();
        public void ChangeStatus(int id, EStatus status)
        {
            var order1 = Orders.FirstOrDefault(q => q.Id == id);
            order1.Status = status;
        }

        public OrderModel AddOrder(ProductModel[] products, string description, string address)
        {
            if (products is null ||
                string.IsNullOrEmpty(description) ||
                string.IsNullOrEmpty(address))
                throw new Exception("Передано пустое значение");
            var order = new OrderModel
            {
                Id = Orders.Count + 1,
                Products = products,
                Description = description,
                Address = address
            };
            Orders.Add(order);
            return order;
        }

        public OrderModel GetOrder(int id)
        {
            var order = Orders.FirstOrDefault(q => q.Id == id);
            return order;
        }

        public OrderModel[] GetOrders()
        {
            OrderModel[] orders = Orders.ToArray();
            return orders.ToArray();
        }
    }
}