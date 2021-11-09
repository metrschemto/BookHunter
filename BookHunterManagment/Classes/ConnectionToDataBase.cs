using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Windows.Media.Imaging;

namespace BookHunterManagment.Classes
{
    class ConnectionToDataBase
    {
        public static MySqlConnection Connection()
        {
            string path = "server=localhost;user=root;password=1234;database=bookhunter_database";
            MySqlConnection conn = new MySqlConnection(path);
            return conn;
        }
        public static void QueryExecution(string Query, string Find, string Sort)
        {
            MySqlConnection conn = ConnectionToDataBase.Connection();
            conn.Open();
            string FinallyQuery = String.Format(Query, Find, Sort);
            MySqlCommand command = new MySqlCommand(FinallyQuery, conn);
            command.ExecuteReader();
        }
        public static List<Classes.Book>BookItem(string Find, string Sort)
        {
            List<Classes.Book> books = new List<Book>();
            MySqlConnection connection = ConnectionToDataBase.Connection();
            connection.Open();
            string Query = "SELECT book_code,book_name,book_genre,author_name,author_surname," +
            "book_count_in_storage,book_cost,publishing_house,age_restriction,publishing_year,pages_count,book_circulation, book_image_path " +
            "FROM books,authors WHERE book_author = authors.author_code {0} {1};";
            string FinallyQuery = String.Format(Query, Find, Sort);
            MySqlCommand command = new MySqlCommand(FinallyQuery, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                string cost = "";
                if (reader.GetInt32(6) < 1000)
                {
                    cost = Convert.ToString(reader.GetInt32(6)) + " руб.";
                }
                else
                {
                    cost = Convert.ToString(reader.GetInt32(6)) + " руб.";
                    cost = cost.Insert(1, " ");
                }
                Classes.Book book = new Book
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
        public static List<Classes.Employee> EmployeeItem(string Find, string Sort)
        {
            List<Classes.Employee> Employees = new List<Employee>();
            MySqlConnection connection = ConnectionToDataBase.Connection();
            connection.Open();
            string Query = "SELECT * FROM users WHERE user_type='1' {0} {1}";
            string FinallyQuery = String.Format(Query, Find, Sort);
            MySqlCommand command = new MySqlCommand(FinallyQuery, connection);
            MySqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                Classes.Employee Employee = new Employee
                {
                    FIO = reader.GetString(6) + " " + reader.GetString(4) + " " + reader.GetString(7),
                    PhoneNumber = reader.GetString(5),
                    ID = reader.GetString(0)
                };
                Employees.Add(Employee);
            }
            return Employees;
        }
    }
}

