using System;
using System.Collections.Generic;
using System.Data;
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
                new MySqlConnection(
                    "server=localhost;dns-srv=false;user id=root;password=password;database=bloodstorageapi");
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

        public static string RetrieveDonorsByRhf(MySqlConnection conn, string rhf, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@rhf", rhf);
                MySqlDataReader rdr = cmd.ExecuteReader();

                List<DonorNameBloodType> donorList = new List<DonorNameBloodType>();
                while (rdr.Read())
                {
                    donorList.Add(new DonorNameBloodType
                    {
                        Name = Convert.ToString(rdr[0]), BloodType = Convert.ToString(rdr[1])
                    });
                }
                rdr.Close();
                string json = JsonConvert.SerializeObject(new {results = donorList}, Formatting.Indented);
                return json;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Console.WriteLine(s);
                return s;
            }
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
                bloodList.Add(new BloodStorage
                {
                    BID = Convert.ToInt32(rdr[0]), ShelfLife = Convert.ToString(rdr[1]),
                    BloodType = Convert.ToString(rdr[2]), Shipped = Convert.ToInt32(rdr[3])
                });
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
            try
            {
                cmd.Parameters.AddWithValue("@potentialdonorID", donorId);
                MySqlDataReader rdr = cmd.ExecuteReader();

                IList<Donor> donorInformation = new List<Donor>();
                while (rdr.Read())
                {
                    donorInformation.Add(new Donor
                    {
                        DonorID = Convert.ToInt32(rdr[0]), Name = Convert.ToString(rdr[1]),
                        BloodType = Convert.ToString(rdr[2]), RHFactor = Convert.ToString(rdr[3]),
                        Points = Convert.ToInt32(rdr[4])
                    });
                }

                rdr.Close();
                string json = JsonConvert.SerializeObject(new {results = donorInformation}, Formatting.Indented);
                Console.WriteLine(json);
                return json;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Console.WriteLine(s);
                return s;
            }
        }

        public static string RetrieveHospitalInformation(MySqlConnection conn, int hospitalId, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@paramHID", hospitalId);
                MySqlDataReader rdr = cmd.ExecuteReader();

                IList<Hospital> hospitalInformation = new List<Hospital>();
                while (rdr.Read())
                {
                    hospitalInformation.Add(new Hospital
                    {
                        HID = Convert.ToInt32(rdr[0]), HospitalLocation = Convert.ToString(rdr[1]),
                        HospitalName = Convert.ToString(rdr[2])
                    });
                }

                rdr.Close();
                string json = JsonConvert.SerializeObject(new {results = hospitalInformation}, Formatting.Indented);
                Console.WriteLine(json);
                return json;
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Console.WriteLine(s);
                return s;
            }
        }

        public static string RetrieveEmployeeInformation(MySqlConnection conn, int employeeId, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
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
            catch (Exception ex)
            {
                string s = ex.Message;
                Console.WriteLine(s);
                return s;
            }
        }

        public static string RetrieveAllEmployeesOfClinic(MySqlConnection conn, int clinicId, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@paramClinicID", clinicId);
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
            catch (Exception ex)
            {
                string s = ex.Message;
                Console.WriteLine(s);
                return s;
            }
        }

        public static void AddHospital(MySqlConnection conn, string hospitalLocation, string hospitalName, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            Console.WriteLine(hospitalLocation);
            Console.WriteLine(hospitalName);
            // cmd.Parameters.AddWithValue("@paramHospitalLocation", hospitalLocation);
            // cmd.Parameters.AddWithValue("@paramHospitalName", hospitalName);
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@paramHospitalLocation", hospitalLocation));
                cmd.Parameters.Add(new MySqlParameter("@paramHospitalName", hospitalName));
                Console.WriteLine("Add Range");
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Console.WriteLine(s);
            }

            Console.WriteLine("done");
            cmd.Connection.Close();
        }

        public static void AddEmployee(MySqlConnection conn, string employeeAddress, string employeePhoneNumber,
            string employeeName, string employeeRole, int employeeClinicID, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@paramAddress", employeeAddress));
                cmd.Parameters.Add(new MySqlParameter("@paramPhoneNumber", employeePhoneNumber));
                cmd.Parameters.Add(new MySqlParameter("@paramName", employeeName));
                cmd.Parameters.Add(new MySqlParameter("@paramRole", employeeRole));
                cmd.Parameters.Add(new MySqlParameter("@paramClinicID", employeeClinicID));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Console.WriteLine(s);
            }
            Console.WriteLine("done");
            cmd.Connection.Close();
        }

        public static string AddBloodStorage(MySqlConnection conn, string shelfLife, string bloodType, int shipped,
            string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.Add(new MySqlParameter("@paramShelfLife", shelfLife));
                cmd.Parameters.Add(new MySqlParameter("@paramBloodType", bloodType));
                cmd.Parameters.Add(new MySqlParameter("@paramShipped", Convert.ToBoolean(shipped)));
                cmd.ExecuteNonQuery();
                cmd.Connection.Close();
                return "Insertion was successful";
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Console.WriteLine(s);
                cmd.Connection.Close();
                return s;
            }

            
        }

        public static void AddDonor(MySqlConnection conn, string name, string bloodType, string rhFactor, int points,
            string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@paramName", name));
                cmd.Parameters.Add(new MySqlParameter("@paramBloodType", bloodType));
                cmd.Parameters.Add(new MySqlParameter("@paramRHFactor", rhFactor));
                cmd.Parameters.Add(new MySqlParameter("@paramPoints", points));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                string s = ex.Message;
                Console.WriteLine(s);
            }

            Console.WriteLine("done");
            cmd.Connection.Close();
        }

        public static string RetrieveAllEmployees(MySqlConnection conn, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                MySqlDataReader rdr = cmd.ExecuteReader();
                IList<Employee> employeeList = new List<Employee>();
                while (rdr.Read())
                {
                    employeeList.Add(new Employee
                    {
                        EmployeeID = Convert.ToInt32(rdr[0]), Address = Convert.ToString(rdr[1]),
                        PhoneNumber = Convert.ToString(rdr[2]), Name = Convert.ToString(rdr[3]),
                        Role = Convert.ToString(rdr[4]), ClinicID = Convert.ToInt32(rdr[5])
                    });
                }

                rdr.Close();
                string json = JsonConvert.SerializeObject(new {results = employeeList}, Formatting.Indented);
                Console.WriteLine(json);
                return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }

        public static string RetrieveAllDonors(MySqlConnection conn, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                MySqlDataReader rdr = cmd.ExecuteReader();
                IList<Donor> donorList = new List<Donor>();
                while (rdr.Read())
                {
                    donorList.Add(new Donor
                    {
                        DonorID = Convert.ToInt32(rdr[0]), Name = Convert.ToString(rdr[1]),
                        BloodType = Convert.ToString(rdr[2]), RHFactor = Convert.ToString(rdr[3]),
                        Points = Convert.ToInt32(rdr[4])
                    });
                }

                rdr.Close();
                string json = JsonConvert.SerializeObject(new {results = donorList}, Formatting.Indented);
                Console.WriteLine(json);
                return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }

        public static void UpdateHospitalName(MySqlConnection conn, int hid, string hospitalName, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@paramHID", hid));
                cmd.Parameters.Add(new MySqlParameter("@paramHospitalName", hospitalName));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("done");
            cmd.Connection.Close();
        }

        public static void UpdateDonorName(MySqlConnection conn, int donorId, string donorName, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@paramDonorID", donorId));
                cmd.Parameters.Add(new MySqlParameter("@paramDonorName", donorName));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("done");
            cmd.Connection.Close();
        }
        
        public static void AddDonorPoints(MySqlConnection conn, int donorId, int donorPoints, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@paramDonorID", donorId));
                cmd.Parameters.Add(new MySqlParameter("@paramDonorPoints", donorPoints));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("done");
            cmd.Connection.Close();
        }

        public static void UpdateBloodStorage(MySqlConnection conn, int bid, int shipped, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@paramBID", bid));
                cmd.Parameters.Add(new MySqlParameter("@paramShipped", Convert.ToBoolean(shipped)));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("done");
            cmd.Connection.Close();
        }
        
        public static string GetEvent(MySqlConnection conn, string date, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@paramEventDate", date);
            MySqlDataReader rdr = cmd.ExecuteReader();

            List<Events> eventList = new List<Events>();
            while (rdr.Read())
            {
                Console.WriteLine(rdr[0] + " --- " + rdr[1] + "---" + rdr[2] + "---" + rdr[3] );
                eventList.Add(new Models.Events()
                {
                    EventDate = Convert.ToString(rdr[0]), EventLocation = Convert.ToString(rdr[1]),
                    ClinicID = Convert.ToInt16(rdr[2]), ManagerID = Convert.ToInt32(rdr[3])
                });
            }
            rdr.Close();
            string json = JsonConvert.SerializeObject(new {results = eventList}, Formatting.Indented);
            return json;
        }
        
        public static void InsertEvent(MySqlConnection conn, Events events, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@paramEventDate", events.EventDate));
                cmd.Parameters.Add(new MySqlParameter("@paramEventLocation", events.EventLocation));
                cmd.Parameters.Add(new MySqlParameter("@paramClinicID", events.ClinicID));
                cmd.Parameters.Add(new MySqlParameter("@paramManagerID", events.ManagerID));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("done");
            cmd.Connection.Close();
        }
        
        
        public static int InsertPrizeTransaction(MySqlConnection conn, int donorID,int PID, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            int work = -1;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@paramDonorID", donorID));
                cmd.Parameters.Add(new MySqlParameter("@paramPID", PID));
                cmd.Parameters.Add(new MySqlParameter("@paramWork", work));
                cmd.Parameters["@paramWork"].Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                work = (Int32)cmd.Parameters["@paramWork"].Value;
                return work;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return work;
        }


        public static void UpdatePrize(MySqlConnection conn, int PID, int Quantity, int PointsPrice, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@paramPID", PID));
                cmd.Parameters.Add(new MySqlParameter("@paramQuantity", Quantity));
                cmd.Parameters.Add(new MySqlParameter("@paramPointsPrice", PointsPrice));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AddPrize(MySqlConnection conn,int prizeQuantity, int prizePointsPrice, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@paramQuantity", prizeQuantity));
                cmd.Parameters.Add(new MySqlParameter("@paramPointsPrice", prizePointsPrice));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void AddRequest(MySqlConnection conn,int ClinicID, string DateCompleted, int HospitalID, int Amount, string BloodType, string RHFactor, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@paramClinicID", ClinicID));
                cmd.Parameters.Add(new MySqlParameter("@paramDateCompleted", DateCompleted));
                cmd.Parameters.Add(new MySqlParameter("@paramHospitalID", HospitalID));
                cmd.Parameters.Add(new MySqlParameter("@paramAmount", Amount));
                cmd.Parameters.Add(new MySqlParameter("@paramBloodType", BloodType));
                cmd.Parameters.Add(new MySqlParameter("@paramRHFactor", RHFactor));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static string RetrieveDonorByBloodType(MySqlConnection conn, string bloodType, string rhf, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@paramBloodType", bloodType);
                cmd.Parameters.AddWithValue("@paramRHF", rhf);
                MySqlDataReader rdr = cmd.ExecuteReader();

                List<Donor> donorList = new List<Donor>();
                while (rdr.Read())
                {
                    donorList.Add(new Donor
                    {
                        DonorID = Convert.ToInt32(rdr[0]), Name = Convert.ToString(rdr[1]), 
                        BloodType = Convert.ToString(rdr[2]), RHFactor = Convert.ToString(rdr[3]),
                        Points = Convert.ToInt32(rdr[4])
                    });
                }
                rdr.Close();
                string json = JsonConvert.SerializeObject(new {results = donorList}, Formatting.Indented);
                return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }
    }
}