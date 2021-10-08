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

        [TestCase("Молоко", 150)]
        [TestCase("Хлеб", 333)]
        [TestCase("Яблоко", 444)]

        [Test]
        public void CreateProduct(string name, decimal price)
        {
            var productService = new ProductService();
            var product = productService.CreateProduct(name, price);
            Assert.AreEqual(product.Name, name);
            Assert.AreEqual(product.Price, price);
        }

        [TestCase("", 444)]
        [TestCase("Яблоко", -444)]

        public void CreateProductWithThrow(string name, decimal price)
        {
            var productService = new ProductService();
            Assert.Throws<Exception>(() => productService.CreateProduct(name, price));
        }
        [TestCase("Хлеб", "Хлеб белый", "Екатеринбург")]
        
        public void AddOrder(ProductModel[] products, string description, string address)
        {
            OrderService orderService = new OrderService();
            var order = orderService.AddOrder(products, description, address);
            Assert.AreEqual(order.Products, products);
            Assert.AreEqual(order.Description, description);
            Assert.AreEqual(order.Address, address);
        }

        //[TestCase("Хлеб", "", "Екатеринбург")]
        //[TestCase("", "Молоко свежий","Екатеринбург")]
        //[TestCase("Яблоко", "Яблоко красное", "")]

        //public void AddOrderWithThrow(ProductModel[] products, string description, string address)
        //{
        //    var orderService = new OrderService();
        //    Assert.Throws<Exception>(() => orderService.AddOrder(products, description, address));
        //}
    }
}