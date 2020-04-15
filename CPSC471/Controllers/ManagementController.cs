using System;
using System.Data;
using CPSC471.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace CPSC471.Controllers
{
    public class ManagementController : Controller
    {
        //getting connection
        private MySqlConnection conn = DBcon.getconn();
        
        // GET Management/AllEmployees
        [HttpGet]
        [Route("Management/AllEmployees")]
        public string GetAllEmployees()
        {
            string json = DBcon.RetrieveAllEmployees(conn, "getAllEmployees");
            return json;
        }
        
        // POST Management/InsertEmployee
        [HttpPost]
        [Route("Management/InsertEmployee")]
        public string InsertEmployee([FromBody] Employee employee)
        {
            DBcon.AddEmployee(conn, employee.Address, employee.PhoneNumber,employee.Name, employee.Role, employee.ClinicID, "addEmployee");
            return "Insertion was successful";
        }
        
        // GET Management/EmployeeClinic/1/
        [HttpGet]
        [Route("Management/EmployeeClinic/{ClinicID}/")]
        public string GetEmployeesAtClinic(int clinicId)
        {
            string json = DBcon.RetrieveAllEmployeesOfClinic(conn, clinicId, "getAllEmployeesOfClinic");
            return json;
        }
        
        // GET Management/Employee/4/
        [HttpGet]
        [Route("Management/Employee/{EmployeeID}/")]
        public string GetEmployeeInformation(int employeeId)
        {
            string json = DBcon.RetrieveEmployeeInformation(conn, employeeId, "getEmployeeInfo");
            return json;
        }
        
        // GET Management/GetBloodStorage
        [HttpGet]
        [Route("Management/GetBloodStorage")]
        public string GetBloodStorage()
        {
            string json = DBcon.RetrieveBloodStorage(conn, "getBloodStorage");
            return json;
        }
        
        // POST Management/InsertEvent
        [HttpPost]
        [Route("Management/InsertEvent")]
        public string InsertEvent([FromBody] Events events)
        {
            DBcon.InsertEvent(conn, events, "addEvent");
            return "Insert successful";
        }
        
        // POST Management/AddPrize
        [HttpPost]
        [Route("Management/AddPrize")]
        public string AddPrize([FromBody] Prize prize)
        {
            DBcon.AddPrize(conn, prize.Quantity, prize.PointsPrice, "AddPrize");
            return "added prize";
        }
        
        // POST Management/AddVolunteerEvent
        [HttpPost]
        [Route("Management/AddVolunteerEvent")]
        public string AddVolunteerEvent([FromBody] EventVolunteer ev)
        {
            DBcon.AddVolunteerEvent(conn, ev.eventID, ev.volunteerID, "AddVolunteerEvent");
            return "Volunteer " + ev.volunteerID + " added to " + ev.eventID;
        }
        
        // GET Management/VolunteersEvent
        [HttpGet]
        [Route("Management/GetVolunteersEvent/{EventID}")]
        public string GetVolunteersEvent(string EventID)
        {
            string json = DBcon.GetVolunteersEvent(conn, EventID, "GetVolunteersEvent");
            return json;
        }
        
        // POST Management/AddEmployeeEvent
        [HttpPost]
        [Route("Management/AddEmployeeEvent")]
        public string AddEmployeeEvent([FromBody] EventEmployee ee)
        {
            DBcon.AddEmployeeEvent(conn, ee.eventID, ee.employeeID, "AddEmployeeEvent");
            return "Employee " + ee.employeeID + " added to " + ee.eventID;
        }
        
        // GET Management/EmployeeEvent
        [HttpGet]
        [Route("Management/EmployeeEvent/{EventID}")]
        public string GetEmployeeEvent(string EventID)
        {
            string json = DBcon.GetEmployeeEvent(conn, EventID, "GetEmployeeEvent");
            return json;
        }
    }
}