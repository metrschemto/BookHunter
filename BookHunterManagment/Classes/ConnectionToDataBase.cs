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
            string path = "server=localhost;user=root;password=Powerdog132;database=bookhunter_database";
            MySqlConnection conn = new MySqlConnection(path);
            return conn;
        }
        public void QueryExecution(string Query, string Find, string Sort)
        {
            MySqlConnection conn = ConnectionToDataBase.Connection();
            conn.Open();
            string FinallyQuery = String.Format(Query, Find, Sort);
            MySqlCommand command = new MySqlCommand(Query, conn);
            command.ExecuteReader();
        }
    }
}

