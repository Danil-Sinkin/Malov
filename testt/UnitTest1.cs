using ConsoleApp1;
using ConsoleApp1.Enums;
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

        [TestCase("ћолоко", 150.0)]
        [TestCase("’леб", 333.0)]
        [TestCase("яблоко", 444.0)]

        [Test]
        public void CreateProduct(string name, decimal price)
        {
            var productService = new ProductService();
            var product = productService.CreateProduct(name, price);
            Assert.AreEqual(product.Name, name);
            Assert.AreEqual(product.Price, price);
        }

        [TestCase("", 444.0)]
        [TestCase("яблоко", -444.0)]
        public void CreateProductWithThrow(string name, decimal price)
        {
            var productService = new ProductService();
            Assert.Throws<Exception>(() => productService.CreateProduct(name, price));
        }

        [TestCaseSource(nameof(ProductsCase))]
        public void ProductsTest(int id, string name, decimal price)
        {
            ProductService productService = new ProductService();
            var product = productService.CreateProduct(name, price);
            Assert.AreEqual(product.Name, name);
            Assert.AreEqual(product.Price, price);
        }

        static object[] ProductsCase =
        {
            new object[] { 4,"’леб",333.0M}
        };

        [TestCase(nameof(ProductsCase), "’леб", "’леб’леб’леб")]

        public void AddOrder(ProductModel[] products,string description, string address)
        {
            OrderService orderService = new OrderService();

            var order = orderService.AddOrder(products,description, address);

            Assert.AreEqual(order.Products, products);
            Assert.AreEqual(order.Description, description);
            Assert.AreEqual(order.Address, address);
        }

        

        public void AddOrderWithThrow(ProductModel[] products,string description, string address)
        {
            var orderService = new OrderService();
            Assert.Throws<Exception>(() => orderService.AddOrder(products,description, address));
        }

        [TestCase(4, EStatus.New)]

        public void ChangeStatus(int id, EStatus status)
        {
            OrderService orderService = new OrderService();
            var estatus = orderService.ChangeStatus(id, status);
            Assert.AreEqual(estatus.Id, id);
            Assert.AreEqual(estatus.Status, status);
        }

        [TestCase(4, 11)]

        public void ChangeStatusWithThrow(int id, EStatus status)
        {
            OrderService orderService = new OrderService();
            Assert.Throws<Exception>(() => orderService.ChangeStatus(id, status));
        }

        [TestCase(12, 233.0)]
        [Test]

        public void ChangePrice(int id, decimal price)
        {
            ProductService productService = new ProductService();
            var product = productService.ChangePrice(id, price);
            Assert.AreEqual(product.Id, id);
            Assert.AreEqual(product.Price, price);
        }

        [TestCase(12, -233.0)]
        [Test]

        public void ChangePriceWithThrow(int id, decimal price)
        { 
            var productService = new ProductService();
            Assert.Throws<Exception>(() => productService.ChangePrice(id, price));
        }
    }
}