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
    public class DeleteModel : PageModel
    {
        private readonly Service_App.Data.Service_AppContext _context;

        public DeleteModel(Service_App.Data.Service_AppContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.AppointmentStatus == null)
            {
                return NotFound();
            }
            var appointmentstatus = await _context.AppointmentStatus.FindAsync(id);

            if (appointmentstatus != null)
            {
                AppointmentStatus = appointmentstatus;
                _context.AppointmentStatus.Remove(AppointmentStatus);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
