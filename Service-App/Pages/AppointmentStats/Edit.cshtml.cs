using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Service_App.Data;
using Service_App.Models;

namespace Service_App.Pages.AppointmentStats
{
    public class EditModel : PageModel
    {
        private readonly Service_App.Data.Service_AppContext _context;

        public EditModel(Service_App.Data.Service_AppContext context)
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

            var appointmentstatus =  await _context.AppointmentStatus.FirstOrDefaultAsync(m => m.Id == id);
            if (appointmentstatus == null)
            {
                return NotFound();
            }
            AppointmentStatus = appointmentstatus;
           ViewData["AppointmentId"] = new SelectList(_context.Appointments, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
           

            // Load the existing appointment status from the database
            var existingStatus = await _context.AppointmentStatus
                .FirstOrDefaultAsync(m => m.Id == AppointmentStatus.Id);

            if (existingStatus == null)
            {
                return NotFound();
            }

            // Update only the Status property
            existingStatus.Status = AppointmentStatus.Status;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentStatusExists(AppointmentStatus.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }


        private bool AppointmentStatusExists(int id)
        {
          return (_context.AppointmentStatus?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
