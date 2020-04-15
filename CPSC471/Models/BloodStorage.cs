using System;

namespace CPSC471.Models
{
    public class BloodStorage
    {
        public int BID { get; set; }
        public string ShelfLife { get; set; }
        public string BloodType { get; set; }
        public string RHFactor { get; set; }
        public Boolean Shipped { get; set; }
    }
}