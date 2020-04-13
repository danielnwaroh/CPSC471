using System;
using System.Collections.Generic;
using CPSC471.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CPSC471.Controllers
{
    [Route("api/TestController")]
    [ApiController]
    public class TestController : Controller
    {
        MySqlConnection conn = DBcon.getconn();
        // GET: /api/TestController/Test/
        [HttpGet]
        [Route("Test")]
        public string Index()
        {
            // MySqlConnection conn = DBcon.getconn();
            
            Console.WriteLine("testing");
            
            return "test";
        }
        
        // GET api/TestController/GetDonorsByRHFactor?rhf=positive
        [HttpGet]
        [Route("GetDonorsByRHFactor")]
        public string GetDonorsByRhFactor(string rhf)
        {
            string json = DBcon.RetrieveDonors(conn, rhf, "getDonorByRHF");
            
            Console.WriteLine(json);
            Console.WriteLine(rhf);

            return json;
        }
        
        // GET api/TestController/GetBloodStorage
        [HttpGet]
        [Route("GetBloodStorage")]
        public string GetBloodStorage()
        {
            string json = DBcon.RetrieveBloodStorage(conn, "getBloodStorage");
            return json;
        }
        
        // GET api/TestController/Donor/1/
        [HttpGet]
        [Route("Donor/{DonorID}/")]
        public string GetDonorInformation(int donorId)
        {
            Console.WriteLine("recieved");
            Console.WriteLine(donorId);
            string json = DBcon.RetrieveDonorInformation(conn, donorId, "getDonorInfo");
            return json;
        }
        
        // GET api/TestController/Hospital/3/
        [HttpGet]
        [Route("Hospital/{HosptialID}")]
        public string GetHospitalInformation(int hosptialId)
        {
            string json = DBcon.RetrieveHospitalInformation(conn, hosptialId, "getHospitalInfo");
            return json;
        }
        
        // GET api/TestController/Employee/4/
        [HttpGet]
        [Route("Employee/{EmployeeID}/")]
        public string GetEmployeeInformation(int employeeId)
        {
            Console.WriteLine("recieved");
            Console.WriteLine(employeeId);
            string json = DBcon.RetrieveEmployeeInformation(conn, employeeId, "getEmployeeInfo");
            return json;
        }
        
        // GET api/TestController/EmployeesAtClinic/1/
        [HttpGet]
        [Route("EmployeesAtClinic/{ClinicID}/")]
        public string GetEmployeesAtClinic(int clinicId)
        {
            string json = DBcon.RetrieveAllEmployeesOfClinic(conn, clinicId, "getAllEmployeesOfClinic");
            return json;
        }
        
        // POST api/TestController/InsertEmployee
        [HttpPost]
        [Route("InsertEmployee")]
        public string InsertEmployee([FromBody] Employee employee)
        {
            Console.WriteLine(employee.Address);
            Console.WriteLine(employee.PhoneNumber);
            Console.WriteLine(employee.Name);
            Console.WriteLine(employee.Role);
            Console.WriteLine(employee.ClinicID);
            DBcon.AddEmployee(conn, employee.Address, employee.PhoneNumber,employee.Name, employee.Role, employee.ClinicID, "addEmployee");
            return "Insertion was successful";
        }
        
        // GET api/TestController/Event/{EventID}/
        
        // POST api/TestController/AddHospital
        [HttpPost]
        [Route("AddHospital")]
        [ActionName("AddHospital")]
        public string AddNewHospital([FromBody] Hospital hospital)
        {
            Console.WriteLine(hospital.HospitalLocation);
            DBcon.AddHospital(conn, hospital.HospitalLocation, hospital.HospitalName,"addHospital");
            // Console.WriteLine(Ok(new string[] { "value1" }));
            return "Insertion was successful";
        }
        
        // POST api/TestController/AddBloodStorage
        [HttpPost]
        [Route("AddBloodStorage")]
        public string AddBloodStorage([FromBody] BloodStorage bloodStorage)
        {
            Console.WriteLine(bloodStorage.ShelfLife);
            Console.WriteLine(bloodStorage.BloodType);
            Console.WriteLine(bloodStorage.Shipped);
            DBcon.AddBloodStorage(conn, bloodStorage.ShelfLife, bloodStorage.BloodType, bloodStorage.Shipped,
                "addBloodStorage");
            return "Insertion was successful";
        }
        
        // POST api/TestController/AddDonor
        [HttpPost]
        [Route("AddDonor")]
        public void AddDonor([FromBody] Donor donor)
        {
            Console.WriteLine(donor.Name);
            Console.WriteLine(donor.BloodType);
            DBcon.AddDonor(conn, donor.Name, donor.BloodType, donor.RHFactor, donor.Points, "addDonor");
        }
        
        // GET api/TestController/AllEmployees
        [HttpGet]
        [Route("AllEmployees")]
        public string GetAllEmployees()
        {
            string json = DBcon.RetrieveAllEmployees(conn, "getAllEmployees");
            return json;
        }
        
        // GET api/TestController/AllDonors
        [HttpGet]
        [Route("AllDonors")]
        public string GetAllDonors()
        {
            string json = DBcon.RetrieveAllDonors(conn, "getAllDonors");
            return json;
        }
        
        
    }
}