using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;


namespace CPSC471.Models
{
    public class DBcon
    {

        //connect to database
        public DBcon()
        {
            Console.WriteLine("DBcon");
        }

        public static MySqlConnection GetConn()
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

        //For clinicController to get donor by RHFactor
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

        //for ManagementController for getting all the information in bloodstorage table
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
                    BloodType = Convert.ToString(rdr[2]), RHFactor = Convert.ToString(rdr[3]),
                    Shipped = Convert.ToBoolean(rdr[4])
                });
            }

            rdr.Close();
            string json = JsonConvert.SerializeObject(new {results = bloodList}, Formatting.Indented);
            Console.WriteLine(json);
            return json;
        }

        //for ClinicController for getting donner information based on donorID
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

        //For HospitalController to get information of a Hospital based on HID
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

        //For ManagementController to get employee information based on employeeID
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

        //For ManagementController to get all the employees working out of a certain clinic
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

        //For HospitalController, used to add a new hospital to the hospital table
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

        //For ManagementController to add a new employee to the employee table
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

        //For ClinicController, used to add more blood to the bloodstorage table
        public static string AddBloodStorage(MySqlConnection conn, string shelfLife, string bloodType, string rhfactor, Boolean shipped,
            string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                cmd.Parameters.Add(new MySqlParameter("@paramShelfLife", shelfLife));
                cmd.Parameters.Add(new MySqlParameter("@paramBloodType", bloodType));
                cmd.Parameters.Add(new MySqlParameter("@paramBloodType", rhfactor));
                cmd.Parameters.Add(new MySqlParameter("@paramShipped", shipped));
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

        //For ClinicController to add a new donor to the donor table
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

        //For the managementController to get all the employees that work at the company
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

        //For ClinicController to get all the donors in the system
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

        //for HospitalController to update information of a hospital
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

        //For ClinicController to update the name of a donor 
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

        //For ClinicController to add points to a donor
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

        //For ManagementController to update information on a bloodstorage
        public static void UpdateBloodStorage(MySqlConnection conn, int bid, Boolean shipped, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@paramBID", bid));
                cmd.Parameters.Add(new MySqlParameter("@paramShipped", shipped));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.WriteLine("done");
            cmd.Connection.Close();
        }

        //For ClinicController to get infomation on an event
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

        //For ManagementController to add a new event to the event table
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
        
        //For ClinicController to make a prize transaction
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

        //For ManagementController to update information on a prize
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

        //For ManagementController to add a new prize to the prize table
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

        //For HosiptalController to make a new request for blood to the clinic
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

        //For ClinicController to get donors by BloodType
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

        //For ManagementController to add a volunteer to an event
        public static void AddVolunteerEvent(MySqlConnection conn, string EventID, in int VolunteerID, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@paramEventID",EventID));
                cmd.Parameters.Add(new MySqlParameter("@paramVolunteerID", VolunteerID));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //For ManagementController to get volunteers attending event
        public static string GetVolunteersEvent(MySqlConnection conn, string eventID, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@paramEventID", eventID);
                MySqlDataReader rdr = cmd.ExecuteReader();

                IList<EventVolunteer> eventVolunteers = new List<EventVolunteer>();
                while (rdr.Read())
                {
                    eventVolunteers.Add(new EventVolunteer()
                    {
                        eventID = Convert.ToString(rdr[0]),
                        volunteerID = Convert.ToInt32(rdr[1]),
                    });
                }
                rdr.Close();
                string json = JsonConvert.SerializeObject(new {results = eventVolunteers}, Formatting.Indented);
                Console.WriteLine(json);
                return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return (ex.Message);
            }
        }

        //For ManagementController to get employees attending event
        public static string GetEmployeeEvent(MySqlConnection conn, string eventID, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@paramEventID", eventID);
                MySqlDataReader rdr = cmd.ExecuteReader();

                IList<EventEmployee> eventEmployee = new List<EventEmployee>();
                while (rdr.Read())
                {
                    eventEmployee.Add(new EventEmployee()
                    {
                        eventID = Convert.ToString(rdr[0]),
                        employeeID = Convert.ToInt32(rdr[1]),
                    });
                }

                rdr.Close();
                string json = JsonConvert.SerializeObject(new {results = eventEmployee}, Formatting.Indented);
                Console.WriteLine(json);
                return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }

        //For ManagementController to add a employee to an event
        public static void AddEmployeeEvent(MySqlConnection conn, string EventID, in int EmployeeID, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@paramEventID",EventID));
                cmd.Parameters.Add(new MySqlParameter("@paramEmployeeID", EmployeeID));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        
        //For ManagementController to view all hospital requests
        public static string RetrieveAllRequests(MySqlConnection conn, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                MySqlDataReader rdr = cmd.ExecuteReader();
                IList<Request> requestList = new List<Request>();
                while (rdr.Read())
                {
                    requestList.Add(new Request
                    {
                        RequestID = Convert.ToInt32(rdr[0]), ClinicID = Convert.ToInt32(rdr[1]),
                        DateCompleted = Convert.ToString(rdr[2]), HospitalID = Convert.ToInt32(rdr[3]),
                        Amount = Convert.ToInt32(rdr[4]), BloodType = Convert.ToString(rdr[5]),
                        RHFactor = Convert.ToString(rdr[6]), Approved = Convert.ToBoolean(rdr[7]),
                        ApprovedBy = Convert.ToInt32(rdr[8])
                    });
                }

                rdr.Close();
                string json = JsonConvert.SerializeObject(new {results = requestList}, Formatting.Indented);
                Console.WriteLine(json);
                return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }
        
        //For ManagementController to get hospital requests by BloodType requested
        public static string RetrieveRequestByBloodType(MySqlConnection conn, string bloodType, string rhf, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.AddWithValue("@paramBloodType", bloodType);
                cmd.Parameters.AddWithValue("@paramRHF", rhf);
                MySqlDataReader rdr = cmd.ExecuteReader();
                IList<Request> requestList = new List<Request>();
                while (rdr.Read())
                {
                    requestList.Add(new Request
                    {
                        RequestID = Convert.ToInt32(rdr[0]), ClinicID = Convert.ToInt32(rdr[1]),
                        DateCompleted = Convert.ToString(rdr[2]), HospitalID = Convert.ToInt32(rdr[3]),
                        Amount = Convert.ToInt32(rdr[4]), BloodType = Convert.ToString(rdr[5]),
                        RHFactor = Convert.ToString(rdr[6]), Approved = Convert.ToBoolean(rdr[7]),
                        ApprovedBy = Convert.ToInt32(rdr[8])
                    });
                }

                rdr.Close();
                string json = JsonConvert.SerializeObject(new {results = requestList}, Formatting.Indented);
                Console.WriteLine(json);
                return json;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex.Message;
            }
        }

        //For ManagementController to update a request
        public static void UpdateRequest(MySqlConnection conn, int requestId, Boolean approved, int approvedBy, string stp)
        {
            MySqlCommand cmd = new MySqlCommand(stp, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                cmd.Parameters.Add(new MySqlParameter("@paramRequestID", requestId));
                cmd.Parameters.Add(new MySqlParameter("@paramApproved", approved));
                cmd.Parameters.Add(new MySqlParameter("@paramApprovedBy", approvedBy));
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
