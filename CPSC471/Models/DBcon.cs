using System;
using System;
using System.Data;

using MySql.Data;
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
                string rtn = "new_procedure";
                MySqlCommand cmd = new MySqlCommand(rtn, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@con", "positive");
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " --- " + rdr[1]);
                }
                rdr.Close();
                Console.WriteLine("YES");
            }
            catch (Exception e)
            {
                Console.WriteLine("No");
                Console.WriteLine(e.ToString());
            }

            return conn;
        }
    }
}