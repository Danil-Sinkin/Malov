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

        [TestCase("Хлеб", 333.0)]

        [Test]
        public void CreateProduct(string name, decimal price)
        {
            var productService = new ProductService();
            var product = productService.CreateProduct(name, price);
            Assert.AreEqual(product.Name, name);
            Assert.AreEqual(product.Price, price);
        }

        [TestCase("", 444.0)]
        [TestCase("Яблоко", -444.0)]

        public void CreateProductWithThrow(string name, decimal price)
        {
            var productService = new ProductService();
            Assert.Throws<Exception>(() => productService.CreateProduct(name, price));
        }

        private static object[] _ProductList =
        {
            new object[] {
                 new List<ProductOrderModel>()
                {new ProductOrderModel{
                    productModels  =new ProductModel{Id = 1, Name = "Хлеб", Price = 12}
                } },
                "Хлеб свежий", "Екатеринбург" }
        };

        [TestCaseSource("_ProductList")]

        public void AddOrder(List<ProductOrderModel> products,string description, string address)
        {
            OrderService orderService = new OrderService();
            orderService.AddOrder(products.ToArray(),description, address);
            var order = orderService.GetOrder(1);
            Assert.AreEqual(description,order.Description );
            Assert.AreEqual(address,order.Address );
            Assert.Pass();
        }

        private static object[] _sourceLists =
        {
            new object[] {
                new List<ProductOrderModel>()
                {new ProductOrderModel{
                    productModels  =new ProductModel{Id = 1, Name = "Хлеб", Price = 12}
                } },
                null, "Екатеринбург" },
            new object[] { new List<ProductOrderModel>() 
            { new ProductOrderModel { productModels = new ProductModel{Id = 1, Name = "Хлеб", Price = 12}

            } },
            "Хлеб свежий",null}
        };

        [TestCaseSource("_sourceLists")]

        public void AddOrderWithThrow(List<ProductOrderModel> products,string description, string address)
        {
            var orderService = new OrderService();
            Assert.Throws<Exception>(() => orderService.AddOrder(products.ToArray(),description, address));
        }

        [TestCase(4, EStatus.New)]

        public void ChangeStatus(int id, EStatus status)
        {
            OrderService orderService = new OrderService();
            var products = new List<ProductOrderModel>()
            {new ProductOrderModel{
                productModels  =new ProductModel{Id = 1, Name = "Хлеб", Price = 12}
            } };
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
            var products = new List<ProductOrderModel>()
            {new ProductOrderModel{
                productModels  =new ProductModel{Id = 1, Name = "Хлеб", Price = 12}
            } };
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