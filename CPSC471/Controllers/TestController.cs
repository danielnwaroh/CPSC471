using CPSC471.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

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
            
            return "test";
        }
    }
}