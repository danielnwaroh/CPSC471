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
            DBcon.AddHospital(conn, hospital.HospitalLocation, hospital.HospitalName,"addHospital");
            return "Insertion was successful";
        }
        
        // PUT Hospital/UpdateHospital
        [HttpPut]
        [Route("Hospital/UpdateHospital")]
        public string UpdateHospital([FromBody] Hospital hospital)
        {
            Console.WriteLine("HID: "+hospital.HID);
            Console.WriteLine("Location: "+hospital.HospitalLocation);
            Console.WriteLine("Name: "+hospital.HospitalName);
            DBcon.UpdateHospitalName(conn, hospital.HID, hospital.HospitalName, "updateHospitalName");
            return "Update was successful";
        }
        
        // POST Hostpital/AddRequest
        [HttpPost]
        [Route("Hospital/AddRequest")]
        public string AddRequest([FromBody] Request request)
        {
            DBcon.AddRequest(conn, request.ClinicID, request.DateCompleted, request.HospitalID, request.Amount,
                request.BloodType, request.RHFactor, "AddRequest");
            return "Request Made";
        }
        
        // GET Hospital/GetAllRequests
        [HttpGet]
        [Route("Hospital/GetAllRequests")]
        public string RetrieveAllRequests()
        {
            string json = DBcon.RetrieveAllRequests(conn, "getAllRequests");
            return json;
        }
        // GET Hospital/GetRequestByBloodType?bloodType=A&rhf=positive
        [HttpGet]
        [Route("Hospital/GetRequestByBloodType")]
        public string RetrieveRequestByBloodType(string bloodType, string rhf)
        {
            string json = DBcon.RetrieveRequestByBloodType(conn, bloodType, rhf, "getRequestByBloodType");
            return json;
        }
        
        // PUT Hospital/UpdateRequest
        [HttpPut]
        [Route("Hospital/UpdateRequest")]
        public string UpdateRequest([FromBody] Request request)
        {
            DBcon.UpdateRequest(conn, request.RequestID, request.Approved, request.ApprovedBy,
                "updateRequest");
            return "Update successful";

        }
    }
}