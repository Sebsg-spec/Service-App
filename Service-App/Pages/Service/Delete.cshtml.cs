using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service_App.Data;
using Service_App.Models;

namespace Service_App.Pages.Service
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Service_App.Data.Service_AppContext _context;

        public DeleteModel(Service_App.Data.Service_AppContext context)
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

            var services = await _context.Services.FirstOrDefaultAsync(m => m.Id == id);

            if (services == null)
            {
                return NotFound();
            }
            else 
            {
                Services = services;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Services == null)
            {
                return NotFound();
            }
            var services = await _context.Services.FindAsync(id);

            if (services != null)
            {
                Services = services;
                _context.Services.Remove(Services);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
