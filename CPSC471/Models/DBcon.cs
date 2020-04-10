using System;
using MySql.Data.MySqlClient;

namespace CPSC471.Models
{
    public class DBcon
    {
        public static MySqlConnection getconn()
        {
            MySqlConnection conn =
                new MySqlConnection(
                    "server=localhost;dns-srv=false;user id=root;password=password;database=bloodstorageapi");
            try
            {
                conn.Open();
                Console.WriteLine("YES");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            return conn;
        }
    }
}