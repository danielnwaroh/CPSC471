using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BloodDonationAPI.Data;
using BloodDonationAPI.Models;

namespace BloodDonationAPI.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly BloodDonationAPI.Data.BloodDonationAPIContext _context;

        public IndexModel(BloodDonationAPI.Data.BloodDonationAPIContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }

        public async Task OnGetAsync()
        {
            Student = await _context.Student.ToListAsync();
        }
    }
}
