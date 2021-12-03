using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
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
                new ProductList{Id = 1, ImagePath = "/Images/product1.jpg", Name = "Хлеб", Price= 34, CountProduct = 0},
                new ProductList{Id = 2, ImagePath = "/Images/product2.jpg", Name = "Батон", Price= 29, CountProduct = 0},
                new ProductList{Id = 3, ImagePath = "/Images/product3.jpg", Name = "Мука", Price= 56, CountProduct = 0},
                new ProductList{Id = 4, ImagePath = "/Images/product4.jpg", Name = "Масло", Price= 121, CountProduct = 0}
            };
            listProduct.ItemsSource = Products;
        }
        public class ProductList
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string ImagePath { get; set; }
            public decimal Price { get; set; }
            public int CountProduct { get; set; }

        }
        
        private void plus(object sender, RoutedEventArgs e)
        {
            ProductList product = (ProductList)listProduct.ItemsSource;
            product.CountProduct += 1;
            //a++;
            //CountProduct.Text = a.ToString();
            MessageBox.Show(product.CountProduct.ToString());
        }
        
        private void minus(object sender, RoutedEventArgs e)
        {

            //int a = Convert.ToInt32(CountProduct.Text);
            //CountProduct.Text = Convert.ToString(a--);
            //MessageBox.Show(CountProduct.Text);
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