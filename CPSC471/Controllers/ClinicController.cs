using System;
using CPSC471.Models;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace CPSC471.Controllers
{
    public class ClinicController : Controller
    {
        //getting connection
        MySqlConnection conn = DBcon.getconn();
        
        // GET /Clinic/GetDonorsByRHFactor?rhf=positive
        [HttpGet]
        [Route("/Clinic/GetDonorsByRHFactor")]
        public string GetDonorsByRhFactor(string rhf)
        {
            string json = DBcon.RetrieveDonors(conn, rhf, "getDonorByRHF");
            
            Console.WriteLine(json);
            Console.WriteLine(rhf);

            return json;
        }
        
        // GET /Clinic/Donor/1/
        [HttpGet]
        [Route("Clinic/Donor/{DonorID}/")]
        public string GetDonorInformation(int donorId)
        {
            Console.WriteLine("recieved");
            Console.WriteLine(donorId);
            string json = DBcon.RetrieveDonorInformation(conn, donorId, "getDonorInfo");
            return json;
        }
        
        // POST Clinic/AddBloodStorage
        [HttpPost]
        [Route("Clinic/AddBloodStorage")]
        public string AddBloodStorage([FromBody] BloodStorage bloodStorage)
        {
            Console.WriteLine(bloodStorage.ShelfLife);
            Console.WriteLine(bloodStorage.BloodType);
            Console.WriteLine(bloodStorage.Shipped);
            DBcon.AddBloodStorage(conn, bloodStorage.ShelfLife, bloodStorage.BloodType, bloodStorage.Shipped,
                "addBloodStorage");
            return "Insertion was successful";
        }
        
        // POST Clinic/AddDonor
        [HttpPost]
        [Route("Clinic/AddDonor")]
        public string AddDonor([FromBody] Donor donor)
        {
            Console.WriteLine(donor.Name);
            Console.WriteLine(donor.BloodType);
            DBcon.AddDonor(conn, donor.Name, donor.BloodType, donor.RHFactor, donor.Points, "addDonor");
            return "Insertion was successful";
        }
        
        // GET Clinic/AllDonors
        [HttpGet]
        [Route("Clinic/AllDonors")]
        public string GetAllDonors()
        {
            string json = DBcon.RetrieveAllDonors(conn, "getAllDonors");
            return json;
        }
        
        // PUT Clinic/UpdateDonorName
        [HttpPut]
        [Route("Clinic/UpdateDonorName")]
        public void UpdateDonorName([FromBody] Donor donor)
        {
            DBcon.UpdateDonorName(conn, donor.DonorID, donor.Name, "updateDonorName");
        }
        
        // PUT Clininc/AddDonorPoints
        [HttpPut]
        [Route("Clinic/AddDonorPoints")]
        public void AddDonorPoints([FromBody] Donor donor)
        {
            DBcon.AddDonorPoints(conn, donor.DonorID, donor.Points, "addDonorPoints");
        }
        
        // PUT Clinic/UpdateBloodStorage
        [HttpPut]
        [Route("Clinic/UpdateBloodStorage")]
        public void UpdateBloodStorage([FromBody] BloodStorage bloodStorage)
        {
            DBcon.UpdateBloodStorage(conn, bloodStorage.BID, bloodStorage.Shipped, "updateBloodStorage");
        }
        
    }
}