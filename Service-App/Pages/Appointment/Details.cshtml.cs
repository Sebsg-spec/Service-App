using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service_App.Data;
using Service_App.Models;

namespace Service_App.Pages.Appointment
{
    public class DetailsModel : PageModel
    {
        private readonly Service_App.Data.Service_AppContext _context;

        public DetailsModel(Service_App.Data.Service_AppContext context)
        {
            _context = context;
        }

      public Appointments Appoitments { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)

        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }
            var appointments = await _context.Appointments
            .Include(a => a.Service)
            .FirstOrDefaultAsync(m => m.Id == id);

            var appoitments = await _context.Appointments.FirstOrDefaultAsync(m => m.Id == id);
           
            if (appoitments == null)
            {
                return NotFound();
            }
            else 
            {
                Appoitments = appoitments;
            }
            return Page();
        }
    }
}
