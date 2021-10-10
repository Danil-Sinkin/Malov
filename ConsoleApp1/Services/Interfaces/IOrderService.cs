using ConsoleApp1.Enums;
using ConsoleApp1.Models;

namespace ConsoleApp1.Services.Interfaces
{
    interface IOrderService
    {
        public OrderModel GetOrder(int id);
        public OrderModel[] GetOrders();
        public OrderModel AddOrder(string description, string address, ProductModel[] products);
        public OrderModel ChangeStatus(int id, EStatus status);
    }
}