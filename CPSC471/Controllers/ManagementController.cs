﻿using System;
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
        
        // GET api/TestController/EmployeesAtClinic/1/
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
            Console.WriteLine("recieved");
            Console.WriteLine(employeeId);
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
    }
}