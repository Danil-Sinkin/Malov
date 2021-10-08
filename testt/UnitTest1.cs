using ConsoleApp1;
using ConsoleApp1.Models;
using ConsoleApp1.Services;
using NUnit.Framework;
using System;

namespace testt
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [TestCase("������", 150)]
        [TestCase("����", 333)]
        [TestCase("������", 444)]

        [Test]
        public void CreateProduct(string name, decimal price)
        {
            var productService = new ProductService();
            var product = productService.CreateProduct(name, price);
            Assert.AreEqual(product.Name, name);
            Assert.AreEqual(product.Price, price);
        }

        [TestCase("", 444)]
        [TestCase("������", -444)]

        public void CreateProductWithThrow(string name, decimal price)
        {
            var productService = new ProductService();
            Assert.Throws<Exception>(() => productService.CreateProduct(name, price));
        }
        [TestCase("����", "���� �����", "������������")]
        
        public void AddOrder(ProductModel[] products, string description, string address)
        {
            OrderService orderService = new OrderService();
            var order = orderService.AddOrder(products, description, address);
            Assert.AreEqual(order.Products, products);
            Assert.AreEqual(order.Description, description);
            Assert.AreEqual(order.Address, address);
        }

        //[TestCase("����", "", "������������")]
        //[TestCase("", "������ ������","������������")]
        //[TestCase("������", "������ �������", "")]

        //public void AddOrderWithThrow(ProductModel[] products, string description, string address)
        //{
        //    var orderService = new OrderService();
        //    Assert.Throws<Exception>(() => orderService.AddOrder(products, description, address));
        //}
    }
}