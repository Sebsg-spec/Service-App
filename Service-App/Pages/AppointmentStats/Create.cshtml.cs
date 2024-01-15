using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service_App.Data;
using Service_App.Models;

namespace Service_App.Pages.AppointmentStats
{
    public class CreateModel : PageModel
    {
        private readonly Service_App.Data.Service_AppContext _context;

        public CreateModel(Service_App.Data.Service_AppContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AppointmentId"] = new SelectList(_context.Appointments, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public AppointmentStatus AppointmentStatus { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.AppointmentStatus == null || AppointmentStatus == null)
            {
                return Page();
            }

            _context.AppointmentStatus.Add(AppointmentStatus);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
