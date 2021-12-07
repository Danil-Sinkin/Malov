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
using static AppWindow.Order;

namespace AppWindow
{
    public partial class Orders : Window
    {
        public ObservableCollection<OrderList> Orderss { get; set; }
        public ProductList[] productLists;
        public Orders()
        {
            InitializeComponent();
            Orderss = new ObservableCollection<OrderList>
            {
                new OrderList{Id = 1,Name ="Заказ №1", productList = new []{
                    new ProductList(){ ImagePath = "/Images/product1.jpg",  Name = "Хлеб", Price= 34, CountProduct = 5  },
                    new ProductList(){ ImagePath = "/Images/product1.jpg", Name = "Хлеб", Price = 34, CountProduct = 5 } } },
                new OrderList{Id = 2,Name ="Заказ №2", productList = new []{
                    new ProductList(){ ImagePath = "/Images/product2.jpg",  Name = "Батон", Price= 29, CountProduct = 1} } },
                new OrderList{Id = 3,Name ="Заказ №3", productList = new []{
                    new ProductList(){ ImagePath = "/Images/product3.jpg", Name = "Мука", Price= 56, CountProduct = 2} } },
                new OrderList{Id = 4,Name ="Заказ №4", productList = new []{
                    new ProductList(){ ImagePath = "/Images/product4.jpg",  Name = "Масло", Price= 121, CountProduct = 0} } }
            };
            listOrders.ItemsSource = Orderss;
        }
        public class OrderList
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public ProductList[] productList;

            //public decimal FinalPrice
            //{
            //    get
            //    {
            //        var finalprice = productList.Price * CountProduct;
            //        decimal finprice = 0;
            //        finprice += finalprice;

            //        return finprice;
            //    }
            //}
        }
        private void backOrders(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
