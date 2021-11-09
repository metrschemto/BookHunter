using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace BookHunter.Windows
{
    /// <summary>
    /// Логика взаимодействия для OrderView.xaml
    /// </summary>
    public partial class OrderView : Window
    {
        string OrderId;
        public OrderView(string IdOrder)
        {
            OrderId = IdOrder;
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OrderContent.ItemsSource = Classes.ConnectionToDataBase.OrderItems(OrderId);
            MySqlConnection connection = Classes.ConnectionToDataBase.Connection();
            connection.Open();
            string QueryCostOrder = "SELECT * FROM bookhunter_database.order where order_code = " + OrderId;
            MySqlCommand command = new MySqlCommand(QueryCostOrder, connection);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            CostOrder.Content = "Сумма: " + reader.GetString(2) + " руб.";
            connection.Close();
        }

        private void DeleteBook_Click(object sender, RoutedEventArgs e)
        {
            Classes.OrderItem obj = ((FrameworkElement)sender).DataContext as Classes.OrderItem;
            string DeleteBookQuery = "Delete from bookhunter_database.order_content where order_code = '"+OrderId+"' and book_code = '"+obj.BookCode+"'";
            Classes.ConnectionToDataBase.QueryExecution(DeleteBookQuery);
            string UpdateCostOrder = "update bookhunter_database.order set order_cost = order_cost - " + obj.BookCost +" where order_code = '" + OrderId + "'";
            Classes.ConnectionToDataBase.QueryExecution(UpdateCostOrder);
            MySqlConnection connection = Classes.ConnectionToDataBase.Connection();
            connection.Open();
            string QueryCostOrder = "SELECT * FROM bookhunter_database.order where order_code = " + OrderId;
            MySqlCommand command = new MySqlCommand(QueryCostOrder, connection);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            CostOrder.Content = "Сумма: " + reader.GetString(2) + " руб.";
            connection.Close();
            OrderContent.ItemsSource = Classes.ConnectionToDataBase.OrderItems(OrderId);
            if (OrderContent.Items.Count == 0)
            {
                string DeleteOrder = "Delete from bookhunter_database.order where order_code = '" + OrderId + "'";
                Classes.ConnectionToDataBase.QueryExecution(DeleteOrder);
                MessageBox.Show("Корзина пуста! Добавьте в неё товар");
                OrderId = 0.ToString();
                Catalog catalog = new Catalog(OrderId);
                catalog.Show();
                this.Close();
            }
        }
        private void PaymentButton_Click(object sender, RoutedEventArgs e)
        {
            PaymentSuccesfull.Visibility = Visibility.Visible;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(OrderId);
            Catalog catalog = new Catalog(OrderId);
            catalog.Show();
            this.Close();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string DeleteBookQuery = "Delete from bookhunter_database.order_content where order_code = '" + OrderId + "'";
            Classes.ConnectionToDataBase.QueryExecution(DeleteBookQuery);
            string DeleteOrder = "Delete from bookhunter_database.order where order_code = '" + OrderId + "'";
            Classes.ConnectionToDataBase.QueryExecution(DeleteOrder);
            StartWindow startWindow = new StartWindow();
            startWindow.Show();
            this.Close();
        }
    }
}
