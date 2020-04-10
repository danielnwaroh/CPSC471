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
        // GET: /api/TestController/Test/
        [HttpGet]
        [Route("Test")]
        public string Index()
        {
            MySqlConnection conn = DBcon.getconn();
            
            // Console.WriteLine(DBcon.RetrieveDonors(conn));
            Dictionary<object, object> dict = DBcon.RetrieveDonors(conn);
            Console.WriteLine("testing");
            
            return "test";
        }
        
        // GET api/TestController/GetDonorsByRHFactor?rhf=positive
        [HttpGet]
        [Route("GetDonorsByRHFactor")]
        public string GetValuesById(string rhf)
        {
            MySqlConnection conn = DBcon.getconn();
            Dictionary<object, object> dict = DBcon.RetrieveDonors(conn); 
            
            Console.WriteLine(rhf);
            
            string json = JsonConvert.SerializeObject(dict, Formatting.Indented);
            return json;
            // return new string[] { "value1" };
        }
    }
}