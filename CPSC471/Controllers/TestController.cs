using System;
using CPSC471.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;
using System.Data.SqlClient;

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
            Console.WriteLine("testing");
            
            return "test";
        }
    }
}