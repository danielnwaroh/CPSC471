namespace CPSC471.Models
{
    public class Request
    {
        public int RequestID { get; set; }
        public int ClinicID { get; set; }
        public string DateCompleted { get; set; }
        public int HospitalID { get; set; }
        public int Amount { get; set; }
        public string BloodType { get; set; }
        public string RHFactor { get; set; }
        public bool Approved { get; set; }
        public int ApprovedBy { get; set; }
        
    }
}