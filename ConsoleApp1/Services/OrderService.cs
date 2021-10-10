using ConsoleApp1.Enums;
using ConsoleApp1.Models;
using ConsoleApp1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1
{
    public class OrderService :IOrderService
    {
        public static List<OrderModel> Orders = new List<OrderModel>();
        public OrderModel ChangeStatus(int id, EStatus status)
        {
            var order = Orders.FirstOrDefault(q => q.Id == id);
            //if ((status == EStatus.Accept) ||
            //    (status == EStatus.Finished) ||
            //    (status == EStatus.New))
            //    throw new Exception("Передано пустое значение");
            order.Status = status;
            Orders.Add(order);
            return order;
        }

        public OrderModel AddOrder(string description, string address, ProductModel[] products)
        {
            if ((products is null) ||
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