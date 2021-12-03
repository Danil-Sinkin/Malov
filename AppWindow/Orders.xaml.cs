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
    public partial class Orders : Window
    {
        public ObservableCollection<OrdersList> Orderss { get; set; }
        public Orders()
        {
            InitializeComponent();
            Orderss = new ObservableCollection<OrdersList>
            {
                new OrdersList{Id = 1, Name = "Заказ №1"},
                new OrdersList{Id = 2, Name = "Заказ №2"},
                new OrdersList{Id = 3, Name = "Заказ №3"},
            };
            listOrders.ItemsSource = Orderss;
        }
        private void backOrders(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        public class OrdersList
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
