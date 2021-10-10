using ConsoleApp1;
using ConsoleApp1.Models;
using ConsoleApp1.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;

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



        //public static object[] ProductTests = new[] {
        //      new object[] { 1, "Яблоко", 4.0m } 
        //};

        [TestCase("Хлеб свежий" , "Адрес","ProductsCase")]

        public void ProductsTest(int id, string name, decimal price)
        {
            ProductService productService = new ProductService();
            var product = productService.CreateProduct(name, price);
            Assert.AreEqual(product.Name, name);
            Assert.AreEqual(product.Price, price);
        }

        public static object[] ProductsCase =
        {
            new object[] { 12, "Хлеб", 6.0m }
        };

        public void AddOrder(string description, string address, ProductModel[] products)
        {
            OrderService orderService = new OrderService();

            var order = orderService.AddOrder(description, address, products);
            Assert.AreEqual(order.Products, products);
            Assert.AreEqual(order.Description, description);
            Assert.AreEqual(order.Address, address);
        }

        //[TestCase("Хлеб", "", "Екатеринбург")]
        //[TestCase("", "Молоко свежий","Екатеринбург")]
        //[TestCase("Яблоко", "Яблоко красное", "")]

        public void AddOrderWithThrow(string description, string address, ProductModel[] products)
        {
            var orderService = new OrderService();
            Assert.Throws<Exception>(() => orderService.AddOrder(description, address, products));
        }
    }
}