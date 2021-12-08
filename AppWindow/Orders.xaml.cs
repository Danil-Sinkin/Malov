using ConsoleApp1.Models;
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
using static AppWindow.MainWindow;


namespace AppWindow
{
    public partial class Orders : Window
    {
        public ObservableCollection<OrderList> Orderss { get; set; }
        public ProductModel[] productModel;
        public Orders()
        {
            InitializeComponent();
   
        }
        public class OrderList
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ProductModel[] productModel;

        }
        private void backOrders(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
