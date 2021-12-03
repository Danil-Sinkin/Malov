using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AppWindow
{
    /// <summary>
    /// Логика взаимодействия для Order.xaml
    /// </summary>
    public partial class Order : Window
    {
        public ObservableCollection<OrderList> Orders { get; set; }
        public Order()
        {
            InitializeComponent();
            Orders = new ObservableCollection<OrderList>
            {
                new OrderList{Id = 1, ImagePath = "/Images/product1.jpg", Name = "Хлеб", Price= 34, CountProduct = 5},
                new OrderList{Id = 2, ImagePath = "/Images/product2.jpg", Name = "Батон", Price= 29, CountProduct = 1},
                new OrderList{Id = 3, ImagePath = "/Images/product3.jpg", Name = "Мука", Price= 56, CountProduct = 2},
                new OrderList{Id = 4, ImagePath = "/Images/product4.jpg", Name = "Масло", Price= 121, CountProduct = 0}
            };
            listOrder.ItemsSource = Orders;
        }
        public class OrderList
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string ImagePath { get; set; }
            public decimal Price { get; set; }
            public int CountProduct { get; set; }

            public decimal FinalPrice
            {
                get
                {
                    var finalprice = Price * CountProduct;
                    decimal finprice = 0;
                    finprice += finalprice;

                    return finprice;
                }
            }
        }
        
        private void orders_Click(object sender, RoutedEventArgs e)
        {
            Orders orders = new Orders();
            orders.Show();
            this.Close();
        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
