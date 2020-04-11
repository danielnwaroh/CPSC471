using System;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using MySql.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

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

        public static string[] RetrieveDonors(MySqlConnection conn, string rhf)
        {
            string rtn = "new_procedure";
            MySqlCommand cmd = new MySqlCommand(rtn, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@con", rhf);
            MySqlDataReader rdr = cmd.ExecuteReader();
            
            List<string> donorList = new List<string>();
            while (rdr.Read())
            {
                Console.WriteLine(rdr[0] + " --- " + rdr[1]);
                donorList.Add("{Name:" + rdr[0] + ", BloodType: " + rdr[1] + "}");
            }
            rdr.Close();
            
            string[] donors = donorList.ToArray();
            return donors;
        }

        public static string RetrieveBloodStorage(MySqlConnection conn, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            MySqlDataReader rdr = cmd.ExecuteReader();

            IList<BloodStorage> bloodList = new List<BloodStorage>();
            while (rdr.Read())
            {
                Console.WriteLine(rdr[0] + " --- " + rdr[1] + " --- " + rdr[2] + " --- " + rdr[3]);
                bloodList.Add(new BloodStorage { BID = Convert.ToInt32(rdr[0]), ShelfLife = Convert.ToString(rdr[1]), BloodType = Convert.ToString(rdr[2]), Shipped = Convert.ToInt32(rdr[3])});
            }
            rdr.Close();
            string json = JsonConvert.SerializeObject(new {results = bloodList}, Formatting.Indented);
            Console.WriteLine(json);
            return json;
        }

        public static string RetrieveDonorInformation(MySqlConnection conn, int donorId, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@potentialdonorID", donorId);
            MySqlDataReader rdr = cmd.ExecuteReader();
            
            IList<Donor> donorInformation = new List<Donor>();
            while (rdr.Read())
            {
                donorInformation.Add(new Donor { DonorID = Convert.ToInt32(rdr[0]), Name = Convert.ToString(rdr[1]), BloodType = Convert.ToString(rdr[2]), RHFactor = Convert.ToString(rdr[3]), Points = Convert.ToInt32(rdr[4])});
            }
            rdr.Close();
            string json = JsonConvert.SerializeObject(new {results = donorInformation}, Formatting.Indented);
            Console.WriteLine(json);
            return json;
        }
        
        public static string RetrieveHospitalInformation(MySqlConnection conn, int hospitalId, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@paramHID", hospitalId);
            MySqlDataReader rdr = cmd.ExecuteReader();
            
            IList<Hospital> hospitalInformation = new List<Hospital>();
            while (rdr.Read())
            {
                hospitalInformation.Add(new Hospital { HID = Convert.ToInt32(rdr[0]), HospitalLocation = Convert.ToString(rdr[1]), HospitalName = Convert.ToString(rdr[2]) });
            }
            rdr.Close();
            string json = JsonConvert.SerializeObject(new {results = hospitalInformation}, Formatting.Indented);
            Console.WriteLine(json);
            return json;
        }

        public static string RetrieveEmployeeInformation(MySqlConnection conn, int employeeId, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@paramEmployeeID", employeeId);
            MySqlDataReader rdr = cmd.ExecuteReader();
            
            IList<Employee> employeeInformation = new List<Employee>();
            while (rdr.Read())
            {
                employeeInformation.Add(new Employee
                {
                    EmployeeID = Convert.ToInt32(rdr[0]), 
                    Address = Convert.ToString(rdr[1]), 
                    PhoneNumber = Convert.ToString(rdr[2]),
                    Name = Convert.ToString(rdr[3]),
                    Role = Convert.ToString(rdr[4]),
                    ClinicID = Convert.ToInt32(rdr[5])
                });
            }
            rdr.Close();
            string json = JsonConvert.SerializeObject(new {results = employeeInformation}, Formatting.Indented);
            Console.WriteLine(json);
            return json;
        }
        
        
    }
}