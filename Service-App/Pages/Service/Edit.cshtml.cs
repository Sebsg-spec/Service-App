using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Service_App.Data;
using Service_App.Models;

namespace Service_App.Pages.Service
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Service_App.Data.Service_AppContext _context;

        public EditModel(Service_App.Data.Service_AppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Services Services { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }

            var services =  await _context.Services.FirstOrDefaultAsync(m => m.Id == id);
            if (services == null)
            {
                return NotFound();
            }
            Services = services;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Services).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicesExists(Services.Id))
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

        private bool ServicesExists(int id)
        {
          return (_context.Services?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
