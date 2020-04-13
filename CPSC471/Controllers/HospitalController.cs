using System;
using Microsoft.AspNetCore.Mvc;
using CPSC471.Models;
using MySql.Data.MySqlClient;

namespace CPSC471.Controllers
{
    public class HospitalController : Controller
    {
        //getting connection
        MySqlConnection conn = DBcon.getconn();
        
        // GET Hospital/{HospitalID}
        [HttpGet]
        [Route("/Hospital/{HosptialID}")]
        public string GetHospitalInformation(int hosptialId)
        {
            string json = DBcon.RetrieveHospitalInformation(conn, hosptialId, "getHospitalInfo");
            return json;
        }
        
        // POST Hospital/AddHospital
        [HttpPost]
        [Route("/Hospital/AddHospital")]
        [ActionName("AddHospital")]
        public string AddNewHospital([FromBody] Hospital hospital)
        {
            Console.WriteLine(hospital.HospitalLocation);
            DBcon.AddHospital(conn, hospital.HospitalLocation, hospital.HospitalName,"addHospital");
            // Console.WriteLine(Ok(new string[] { "value1" }));
            return "Insertion was successful";
        }
        
        // PUT Hospital/UpdateHospital
        [HttpPut]
        [Route("Hospital/UpdateHospital")]
        public void UpdateHospital([FromBody] Hospital hospital)
        {
            Console.WriteLine("HID: "+hospital.HID);
            Console.WriteLine("Location: "+hospital.HospitalLocation);
            Console.WriteLine("Name: "+hospital.HospitalName);
            DBcon.UpdateHospitalName(conn, hospital.HID, hospital.HospitalName, "updateHospitalName");
        }
    }
}