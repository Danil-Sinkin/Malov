using System;
using System.Collections;

namespace ConsoleApp1.Models
{
    public class ProductModel: IEnumerable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Name).GetEnumerator();
        }
    }
}
