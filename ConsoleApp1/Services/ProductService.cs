using ConsoleApp1.Models;
using ConsoleApp1.Services.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Services
{
    public class ProductService :IEnumerable, IProductService
    {
        public static List<ProductModel> Products = new List<ProductModel>();
        
        public ProductModel ChangePrice(int id, decimal price)
        {
            if (price < 0)
                throw new Exception("Передано пустое значение");
            var product = Products.FirstOrDefault(w => w.Id == id);
            product = new ProductModel
            {
                Id = id,
                Price = price
            };
            Products.Add(product);
            return product;
        }

        public ProductModel CreateProduct(string name, decimal price)
        {
            if (string.IsNullOrEmpty(name))
                throw new Exception("Передано пустое значение");
            if (price < 0)
                throw new Exception("Цена не может быть меньше 0");
            var product = new ProductModel
            {
                Id = Products.Count + 1,
                Name = name,
                Price = price
            };
            Products.Add(product);
            return product;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Products).GetEnumerator();
        }

        public ProductModel[] GetProducts()
        {
            ProductModel[] products = Products.ToArray();
            return products;
        }
    }
}