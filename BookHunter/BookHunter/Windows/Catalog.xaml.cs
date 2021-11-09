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
    /// Логика взаимодействия для Catalog.xaml
    /// </summary>
    public partial class Catalog : Window
    {
        List<Classes.GenresItem> ItemGenres = new List<Classes.GenresItem>();
        string FindBook;
        string SortBook;
        int CountBookBuy = 1;
        int MaxBookCoun = 1;
        bool isCreateOrder = true;
        string bookcost;
        int orderid;
        string bookid;
        public Catalog(string ReturnOrderCode)
        {
            orderid = Convert.ToInt32(ReturnOrderCode);
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ItemGenres = Classes.ConnectionToDataBase.Genres();
            Genres.ItemsSource = ItemGenres;
        }
        private void Genres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListOfBooks.ItemsSource = null;
            Classes.GenresItem obj = ItemGenres[Genres.SelectedIndex];
            string GenresId = " and book_genre = '" + obj.GenresId + "'";
            ListOfBooks.ItemsSource = Classes.ConnectionToDataBase.BookItem(FindBook, SortBook, GenresId);
        }

        private void AddBook_Click(object sender, RoutedEventArgs e)
        {
            AuthorBook.Content = "Автор: ";
            GenreBook.Content = "Жанр: ";
            CountBook.Content = "Количество на складе: ";
            PublishingHouseBook.Content = "Издательство: ";
            AgeRestrictionBook.Content = "Возрастное ограничение: ";
            YearPublishingBook.Content = "Год издания: ";
            CountPagesBook.Content = "Количество страниц: ";
            CirculationBook.Content = "Тираж: ";
            Classes.BookItem obj = ((FrameworkElement)sender).DataContext as Classes.BookItem;
            InfoAddBook.Visibility = Visibility.Visible;
            ImageBook.Source = obj.bookimage;
            TitleBook.Content = obj.book_name;
            AuthorBook.Content += obj.book_author;
            GenreBook.Content += obj.book_genre;
            CountBook.Content += obj.books_in_storage;
            PublishingHouseBook.Content += obj.publishing_house;
            AgeRestrictionBook.Content += obj.age_restriction;
            YearPublishingBook.Content += obj.publishing_year;
            CountPagesBook.Content += obj.pages_count;
            CirculationBook.Content += obj.book_circulation;
            CostBook.Text = obj.book_cost;
            bookcost = obj.book_cost.Split(' ')[0];
            bookid = obj.ID;
            CountBookBuy = 1;
            MaxBookCoun = Convert.ToInt32(obj.books_in_storage);
            BookCount.Text = "1";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            CountBookBuy++;
            if (CountBookBuy == MaxBookCoun+1)
            {
                CountBookBuy--;
            }
            BookCount.Text = CountBookBuy.ToString();
        }

        private void CountSubtraction_Click(object sender, RoutedEventArgs e)
        {
            CountBookBuy--;
            if (CountBookBuy == 0)
            {
                CountBookBuy++;
            }
            BookCount.Text = CountBookBuy.ToString();
        }

        private void AddBoorToOrder_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection connection = Classes.ConnectionToDataBase.Connection();
            connection.Open();
            string QueryCreateOrder = "select Concat(current_date(),' ',current_time())";
            MySqlCommand command = new MySqlCommand(QueryCreateOrder, connection);
            MySqlDataReader reader = command.ExecuteReader();
            reader.Read();
            string curdatetime = reader.GetString(0);
            connection.Close();
            if (isCreateOrder)
            {
                connection.Open();
                string AllOrders = "select count(basket_code) from bookhunter_database.basket";
                MySqlCommand command1 = new MySqlCommand(AllOrders, connection);
                MySqlDataReader reader1 = command1.ExecuteReader();
                reader1.Read();
                if (reader1.GetInt32(0) == 0)
                {
                    orderid = 1;
                    connection.Close();
                }
                else
                {
                    connection.Close();
                    connection.Open();
                    string QueryOrderMaxID = "select max(basket_code) from bookhunter_database.basket";
                    MySqlCommand command2 = new MySqlCommand(QueryOrderMaxID, connection);
                    MySqlDataReader reader2 = command2.ExecuteReader();
                    reader2.Read();
                    orderid = Convert.ToInt32(reader2.GetString(0)) + 1;
                    connection.Close();
                }
                string InsertOrder = "insert into bookhunter_database.basket(basket_code,basket_date,basket_cost) values ('" + orderid + "','"+ curdatetime + "', basket_cost + " + (Convert.ToInt32(bookcost)*CountBookBuy).ToString()+")";
                Classes.ConnectionToDataBase.QueryExecution(InsertOrder);
                string AddBookOrder = "insert into bookhunter_database.basket_content values('" + orderid+"','"+bookid+"','"+CountBookBuy.ToString()+"')";
                Classes.ConnectionToDataBase.QueryExecution(AddBookOrder);
                MessageBox.Show("Книга успешно добавлена в корзину!");
                isCreateOrder = false;
                InfoAddBook.Visibility = Visibility.Hidden;
            }
            else
            {
                string AddBookOrder = "insert into bookhunter_database.basket_content values('" + orderid + "','" + bookid + "','" + CountBookBuy.ToString() + "')";
                Classes.ConnectionToDataBase.QueryExecution(AddBookOrder);
                string UpdateOrderCost = "update bookhunter_database.basket set basket_cost = basket_cost + " + (Convert.ToInt32(bookcost) * CountBookBuy).ToString() + " where basket_code = '" + orderid+"'";
                Classes.ConnectionToDataBase.QueryExecution(UpdateOrderCost);
                MessageBox.Show("Книга успешно добавлена в корзину!");
                isCreateOrder = false;
                InfoAddBook.Visibility = Visibility.Hidden;
            }
        }

        private void BookCount_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (BookCount.Text != "")
            {
                CountBookBuy = Convert.ToInt32(BookCount.Text);
                if (CountBookBuy < 1)
                {
                    CountBookBuy = 1;
                    BookCount.Text = CountBookBuy.ToString();
                }
                if (CountBookBuy >= MaxBookCoun)
                {
                    CountBookBuy = MaxBookCoun;
                    BookCount.Text = CountBookBuy.ToString();
                }
            }
        }
        private void ExitInfoBook_Click(object sender, RoutedEventArgs e)
        {
            InfoAddBook.Visibility = Visibility.Hidden;
        }
        private void MakeAnOrder_Click(object sender, RoutedEventArgs e)
        {
            if (isCreateOrder && orderid == 0)
            {
                MessageBox.Show("Корзина пуста! Добавьте в неё товар");
            }
            else
            {
                OrderView orderView = new OrderView(orderid.ToString());
                orderView.Show();
                this.Close();
            }
        }
    }
}
