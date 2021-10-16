using ConsoleApp1.Enums;

namespace ConsoleApp1.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public ProductOrderModel[] Products { get; set; }
        public EStatus Status { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }

    }  
}
