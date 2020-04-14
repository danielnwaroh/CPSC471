namespace CPSC471.Models
{
    public class Request
    {
        public int RequestID { get; set; }
        public string DateBy { get; set; }
        public string DateReq { get; set; }
        public int ClinicId { get; set; }
        public string DateCompleted { get; set; }
        public int HospitalID { get; set; }
        public bool isApproved { get; set; }
        
    }
}