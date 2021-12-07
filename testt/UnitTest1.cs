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

        [TestCase("’леб", 333.0)]

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

        private static object[] _ProductList =
        {
            new object[] {
                 new List<ProductOrderModel>()
                {new ProductOrderModel{
                    productModels  =new ProductModel{Id = 1, Name = "’леб", Price = 12}
                } },
                "’леб свежий", "≈катеринбург" }
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

        private static object[] _SourceLists =
        {
            new object[] {
                new List<ProductOrderModel>()
                {new ProductOrderModel{
                    productModels  =new ProductModel{Id = 1, Name = "’леб", Price = 12}
                } },
                null, "≈катеринбург" },
            new object[] { new List<ProductOrderModel>() 
            { new ProductOrderModel { productModels = new ProductModel{Id = 1, Name = "’леб", Price = 12}

            } },
            "’леб свежий",null}
        };

        [TestCaseSource("_SourceLists")]

        public void AddOrderWithThrow(List<ProductOrderModel> products,string description, string address)
        {
            var orderService = new OrderService();
            Assert.Throws<Exception>(() => orderService.AddOrder(products.ToArray(),description, address));
        }

        [TestCase(4, EStatus.New)]

        public void ChangeStatus(int id, EStatus status)
        {
            OrderService orderService = new OrderService();
            
            var Ostatus = orderService.ChangeStatus(id, status);
            Assert.AreEqual(Ostatus.Id, id);
            Assert.AreEqual(Ostatus.Status, status);
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