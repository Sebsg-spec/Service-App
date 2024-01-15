using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service_App.Data;
using Service_App.Models;

namespace Service_App.Pages.AppointmentStats
{
    public class DetailsModel : PageModel
    {
        private readonly Service_App.Data.Service_AppContext _context;

        public DetailsModel(Service_App.Data.Service_AppContext context)
        {
            _context = context;
        }

      public AppointmentStatus AppointmentStatus { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.AppointmentStatus == null)
            {
                return NotFound();
            }

            var appointmentstatus = await _context.AppointmentStatus.FirstOrDefaultAsync(m => m.Id == id);
            if (appointmentstatus == null)
            {
                return NotFound();
            }
            else 
            {
                AppointmentStatus = appointmentstatus;
            }
            return Page();
        }
    }
}
