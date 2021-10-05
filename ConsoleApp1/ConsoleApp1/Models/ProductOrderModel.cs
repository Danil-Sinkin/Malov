
namespace ConsoleApp1.Models
{
    public class ProductOrderModel
    {
        public OrderModel OrderModel { get; set; }
        public ProductModel[] ProductModel { get; set; }
        public  int Count { get; set; }
    }
}
 