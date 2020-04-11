using System;
using System.Collections.Generic;
using CPSC471.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

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
        public ActionResult<IEnumerable<string>> GetDonorsByRhFactor(string rhf)
        {
            // MySqlConnection conn = DBcon.getconn();
            // Dictionary<object, object> dict = DBcon.RetrieveDonors(conn, rhf); 
            string[] donors = DBcon.RetrieveDonors(conn, rhf);
            
            Console.WriteLine(donors);
            Console.WriteLine(rhf);
            
            // string json = JsonConvert.SerializeObject(dict, Formatting.Indented);
            //return json;
            
            return donors;
        }
        
        // GET api/TestController/GetBloodStorage
        [HttpGet]
        [Route("GetBloodStorage")]
        public string GetBloodStorage()
        {
            // MySqlConnection conn = DBcon.getconn();
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
        
        // GET api/TestController/Employee/{ClinicID}/
        
        // GET api/TestController/Event/{EventID}/
    }
}