using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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
    }
}

