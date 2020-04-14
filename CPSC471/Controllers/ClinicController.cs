﻿using System;
using CPSC471.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace CPSC471.Controllers
{
    public class ClinicController : Controller
    {
        //getting connection
        MySqlConnection conn = DBcon.getconn();
        
        // GET Clinic/AllDonors
        [HttpGet]
        [Route("Clinic/AllDonors")]
        public string GetAllDonors()
        {
            string json = DBcon.RetrieveAllDonors(conn, "getAllDonors");
            return json;
        }
        
        // GET /Clinic/GetDonorsByRHFactor?rhf=positive
        [HttpGet]
        [Route("/Clinic/GetDonorsByRHFactor")]
        public string GetDonorsByRhFactor(string rhf)
        {
            string json = DBcon.RetrieveDonorsByRhf(conn, rhf, "getDonorByRHF");
            return json;
        }
        
        // GET /Clinic/Donor/1/
        [HttpGet]
        [Route("Clinic/Donor/{DonorID}/")]
        public string GetDonorInformation(int donorId)
        {
            string json = DBcon.RetrieveDonorInformation(conn, donorId, "getDonorInfo");
            return json;
        }
        
        // POST Clinic/AddBloodStorage
        [HttpPost]
        [Route("Clinic/AddBloodStorage")]
        public string AddBloodStorage([FromBody] BloodStorage bloodStorage)
        {
            string response = DBcon.AddBloodStorage(conn, bloodStorage.ShelfLife, bloodStorage.BloodType, bloodStorage.Shipped,
                "addBloodStorage");
            return response;
        }
        
        // POST Clinic/AddDonor
        [HttpPost]
        [Route("Clinic/AddDonor")]
        public string AddDonor([FromBody] Donor donor)
        {
            DBcon.AddDonor(conn, donor.Name, donor.BloodType, donor.RHFactor, donor.Points, "addDonor");
            return "Insertion was successful";
        }

        // PUT Clinic/UpdateDonorName
        [HttpPut]
        [Route("Clinic/UpdateDonorName")]
        public string UpdateDonorName([FromBody] Donor donor)
        {
            DBcon.UpdateDonorName(conn, donor.DonorID, donor.Name, "updateDonorName");
            return "Update(PUT) was successful";
        }
        
        // PUT Clininc/AddDonorPoints
        [HttpPut]
        [Route("Clinic/AddDonorPoints")]
        public string AddDonorPoints([FromBody] Donor donor)
        {
            DBcon.AddDonorPoints(conn, donor.DonorID, donor.Points, "addDonorPoints");
            return "Update(PUT) was successful"; 
        }
        
        // PUT Clinic/UpdateBloodStorage
        [HttpPut]
        [Route("Clinic/UpdateBloodStorage")]
        public string UpdateBloodStorage([FromBody] BloodStorage bloodStorage)
        {
            DBcon.UpdateBloodStorage(conn, bloodStorage.BID, bloodStorage.Shipped, "updateBloodStorage");
            return "Update(PUT) was successful"; 
        }
        
    }
}