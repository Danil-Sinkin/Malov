using ConsoleApp1.Enums;
using ConsoleApp1.Models;
using ConsoleApp1.Services.Interfaces;
using System;
using System.Collections;
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
            if (status ==0 )
            {
                order = new OrderModel
                {
                    Id = id,
                    Status = status
                };
            }
            else
            {
                throw new Exception("Передано пустое значение");
            }
            Orders.Add(order);
            return order;
        }

        public OrderModel AddOrder(ProductOrderModel[] products,string description, string address)
        {
            if ((products is null) ||
                string.IsNullOrEmpty(description) ||
                string.IsNullOrEmpty(address))
                throw new Exception("Передано пустое значение");

            var order = new OrderModel
            {
                Id = Orders.Count + 1,
                Products = products.ToArray(),
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