using ConsoleApp1.Models;

namespace ConsoleApp1.Services.Interfaces
{
    public interface IProductService
    {
        public ProductModel CreateProduct(string name, decimal price);
        public ProductModel[] GetProducts();
        public ProductModel ChangePrice(int id, decimal price);
    }
}
