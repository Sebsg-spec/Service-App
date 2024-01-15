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

namespace Service_App.Pages.Appointment
{
    public class EditModel : PageModel
    {
        private readonly Service_App.Data.Service_AppContext _context;

        public EditModel(Service_App.Data.Service_AppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Appointments Appoitments { get; set; } = default!;
        public SelectList LocationsList { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }
            LocationsList = new SelectList(_context.Services, "Id", "Location");
            var appoitments =  await _context.Appointments.FirstOrDefaultAsync(m => m.Id == id);
            if (appoitments == null)
            {
                return NotFound();
            }
            Appoitments = appoitments;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                LocationsList = new SelectList(_context.Services, "Id", "Location");
                return Page();
            }

            _context.Attach(Appoitments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppoitmentsExists(Appoitments.Id))
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

        private bool AppoitmentsExists(int id)
        {
          return (_context.Appointments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
