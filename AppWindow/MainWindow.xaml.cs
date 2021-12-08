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
        public ObservableCollection<ProductModel> Products { get; set; }

  
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            listProduct.ItemsSource = new ProductOrderModel[] { 
             new ProductOrderModel()
            { ProductModels = new[] {
             new ProductModel() { ImagePath = "/Images/product1.jpg", Name = "Манник", Price = 25 } } },
             new ProductOrderModel()
            { ProductModels = new[] {
             new ProductModel() { ImagePath = "/Images/product2.jpg", Name = "Курник", Price =  37} } },
             new ProductOrderModel()
            { ProductModels = new[] {
             new ProductModel() { ImagePath = "/Images/product3.jpg", Name = "Шарлотка", Price = 40 } } },
             new ProductOrderModel()
            { ProductModels = new[] {
             new ProductModel() { ImagePath = "/Images/product4.jpg", Name = "Сочник с творогом", Price = 40 } } },
             new ProductOrderModel()
            { ProductModels = new[] {
             new ProductModel() { ImagePath = "/Images/product5.jpg", Name = "Пирожок с капустой", Price = 30 } } } };
        }

        private void plus(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            ProductOrderModel product = button.DataContext as ProductOrderModel;
            product.Count += 1;
            listProduct.Items.Refresh();
        }
        
        private void minus(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            ProductOrderModel product = button.DataContext as ProductOrderModel;
            if (product.Count > 0) { product.Count -= 1;}
            listProduct.Items.Refresh();
        }

        private void Order(object sender, RoutedEventArgs e)
        {
            Zakazat zakaz = new Zakazat();
            zakaz.Show();
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