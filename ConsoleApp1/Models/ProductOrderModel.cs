﻿
namespace ConsoleApp1.Models
{
    public class ProductOrderModel
    {
        public ProductModel productModels;

        public OrderModel OrderModel { get; set; }
        public ProductModel[] ProductModels { get; set; }
        public  int Count { get; set; }
    }
}
 