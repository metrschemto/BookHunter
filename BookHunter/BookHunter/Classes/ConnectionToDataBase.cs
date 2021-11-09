using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Windows.Media.Imaging;

namespace BookHunter.Classes
{
    class ConnectionToDataBase
    {
        public static MySqlConnection Connection()
        {
            string path = "server=localhost;user=root;password=1234;database=bookhunter_database";
            MySqlConnection conn = new MySqlConnection(path);
            return conn;
        }
        public static void QueryExecution(string Query)
        {
            MySqlConnection conn = ConnectionToDataBase.Connection();
            conn.Open();
            string FinallyQuery = String.Format(Query);
            MySqlCommand command = new MySqlCommand(FinallyQuery, conn);
            command.ExecuteReader();
        }
        public static List<GenresItem> Genres()
        {
            List<GenresItem> items = new List<GenresItem>();
            MySqlConnection connection = ConnectionToDataBase.Connection();
            connection.Open();
            string Query = "SELECT * FROM bookhunter_database.genres;";
            MySqlCommand command = new MySqlCommand(Query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                GenresItem item = new GenresItem
                {
                    GenresId = reader.GetString(0),
                    ImagePathGenre = "хуй",
                    NameGenre = reader.GetString(1)
                };
                items.Add(item);
            }
            return items;
        }
        public static List<Classes.BookItem> BookItem(string Find, string Sort, string IdGenre)
        {
            List<Classes.BookItem> books = new List<BookItem>();
            MySqlConnection connection = ConnectionToDataBase.Connection();
            connection.Open();
            string Query = "SELECT book_code, book_name, genre_name, author_surname, " +
                "author_patronymic, book_count_in_storage, book_cost, publishing_house_name, restriction_name, publishing_year, pages_count, book_circulation, book_image_path " +
                "from books, authors, genres, age_restrictions, publishing_houses" +
                " WHERE book_genre = genre_code and book_author = author_code and " +
                "restriction_code = age_restriction and publishing_house_code = publishing_house {0} {1} {2};";
            string FinallyQuery = String.Format(Query, Find,IdGenre,Sort);
            MySqlCommand command = new MySqlCommand(FinallyQuery, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                string cost = "";
                cost = Convert.ToString(reader.GetInt32(6)) + " руб.";
                Classes.BookItem book = new BookItem
                {
                    ID = reader.GetString(0),
                    book_name = reader.GetString(1),
                    book_genre = reader.GetString(2),
                    book_author = reader.GetString(4) + " " + reader.GetString(3)[0] + ".",
                    books_in_storage = reader.GetString(5),
                    book_cost = cost,
                    publishing_house = reader.GetString(7),
                    age_restriction = reader.GetString(8),
                    publishing_year = reader.GetString(9),
                    pages_count = reader.GetString(10),
                    book_circulation = reader.GetString(11),
                    bookimage = new BitmapImage(new Uri("H:\\Книги\\" + reader.GetString(12)))
                };
                books.Add(book);
            }
            return books;
        }
        public static List<Classes.OrderItem> OrderItems (string OrderID)
        {
            List<Classes.OrderItem> orderitems = new List<OrderItem>();
            MySqlConnection connection = ConnectionToDataBase.Connection();
            connection.Open();
            string Query = "select basket_code, basket_content.book_code, books.book_name, author_surname,author_patronymic,basket_content.count,book_image_path,book_cost from authors,books,basket_content where books.book_code = basket_content.book_code and book_author = author_code and basket_code = " + OrderID;
            MySqlCommand command = new MySqlCommand(Query, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Classes.OrderItem item = new OrderItem
                {
                    OrderCode = reader.GetString(0),
                    BookCode = reader.GetString(1),
                    BookName = reader.GetString(2),
                    BookAuthor = reader.GetString(4) + " " + reader.GetString(3)[0] + ".",
                    BookCount = reader.GetString(5) + " шт.",
                    ImageBook = new BitmapImage(new Uri("H:\\Книги\\" + reader.GetString(6))),
                    BookCost = reader.GetString(7)
                };
                orderitems.Add(item);
            }
            return orderitems;
        }
    }
}
