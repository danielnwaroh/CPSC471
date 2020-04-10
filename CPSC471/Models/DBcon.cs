using System;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace CPSC471.Models
{
    public class DBcon
    {

        public DBcon()
        {
            Console.WriteLine("DBcon");
        }
        public static MySqlConnection getconn()
        {
            MySqlConnection conn =
                new MySqlConnection("server=localhost;dns-srv=false;user id=root;password=Olgaland13.;database=bloodstorageapi");
            try
            {
                conn.Open();
                Console.WriteLine("YES");
            }
            catch (Exception e)
            {
                Console.WriteLine("No");
                Console.WriteLine(e.ToString());
            }
            
            return conn;
        }

        public static Dictionary<object, object> RetrieveDonors(MySqlConnection conn)
        {
            string rtn = "new_procedure";
            MySqlCommand cmd = new MySqlCommand(rtn, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@con", "positive");
            MySqlDataReader rdr = cmd.ExecuteReader();
            Dictionary<object, object> dict = new Dictionary<object, object>();
            
            while (rdr.Read())
            {
                dict.Add(rdr[0],rdr[1]);
                Console.WriteLine(rdr[0] + " --- " + rdr[1]);
            }
            rdr.Close();
            return dict;
        }
        
        
    }
}