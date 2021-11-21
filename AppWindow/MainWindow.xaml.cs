using System;
using System.Collections.ObjectModel;
using System.Windows;
using ConsoleApp1;
using ConsoleApp1.Enums;
using ConsoleApp1.Models;
using ConsoleApp1.Services;

namespace AppWindow
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<ProductList> Products { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            Products = new ObservableCollection<ProductList>
            {
                new ProductList{Id = 1, ImagePath = "/Images/product.jpg", Name = "Хлеб", Price= 34, Count = 0},
                new ProductList{Id = 2, ImagePath = "/Images/product.jpg", Name = "Батон", Price= 29, Count = 0},
                new ProductList{Id = 3, ImagePath = "/Images/product.jpg", Name = "Мука", Price= 56, Count = 0},
                new ProductList{Id = 4, ImagePath = "/Images/product.jpg", Name = "Масло", Price= 121, Count = 0}
            };
            listProduct.ItemsSource = Products;
        }
        public class ProductList
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string ImagePath { get; set; }
            public decimal Price { get; set; }
            public int Count { get; set; }

        }
        private void plus(object sender, RoutedEventArgs e)
        {
            ProductList product = (ProductList)listProduct.ItemsSource;
            product.Count = Convert.ToInt32(CountProduct.Text);
            //a++;
            //CountProduct.Text = a.ToString();
            MessageBox.Show(CountProduct.Text);
        }

        private void minus(object sender, RoutedEventArgs e)
        {
            int a = Convert.ToInt32(CountProduct.Text);
            CountProduct.Text = Convert.ToString(a--);
            MessageBox.Show(CountProduct.Text);
        }

        private void Order(object sender, RoutedEventArgs e)
        {
            Order order = new Order();
            order.Show();
            this.Close();
        }

        private void Orders(object sender, RoutedEventArgs e)
        {
            Orders orders = new Orders();
            orders.Show();
            this.Close();
        }
    }
}