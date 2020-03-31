using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BloodDonationAPI.Models;

namespace BloodDonationAPI.Data
{
    public class BloodDonationAPIContext : DbContext
    {
        public BloodDonationAPIContext (DbContextOptions<BloodDonationAPIContext> options)
            : base(options)
        {
        }

        public DbSet<BloodDonationAPI.Models.Student> Student { get; set; }
    }
}
