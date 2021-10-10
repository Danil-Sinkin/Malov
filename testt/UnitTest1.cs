using ConsoleApp1;
using ConsoleApp1.Enums;
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

        [TestCase("Хлеб свежий", "Адрес", "ProductsCase")]

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



        public void AddOrderWithThrow(string description, string address, ProductModel[] products)
        {
            var orderService = new OrderService();
            Assert.Throws<Exception>(() => orderService.AddOrder(description, address, products));
        }

        [TestCaseSource("ChangeStatusCase")]

        public void ChangeStatus(int id, EStatus status)
        {
            OrderService orderService = new OrderService();
            var estatus = orderService.ChangeStatus(id, status);
            Assert.AreEqual(estatus.Id, id);
            Assert.AreEqual(estatus.Status, status);
        }

        public static object[] ChangeStatusCase =
        {
            new object[] { 1, EStatus.New }
        };

        [TestCase(1, 232)]

        public void ChangePrice(int id, decimal price)
        {
            ProductService productService = new ProductService();
            var product = productService.ChangePrice(id, price);
            Assert.AreEqual(product.Id, id);
            Assert.AreEqual(product.Price, price);
        }

        public static object[] ChangePriceCase =
        {
            new object[] { 1, 232.0M }
        };
    }
}