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
    public class IndexModel : PageModel
    {
        private readonly Service_App.Data.Service_AppContext _context;

        public IndexModel(Service_App.Data.Service_AppContext context)
        {
            _context = context;
        }

        public IList<Appointments> Appoitments { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Appointments != null)
            {
                Appoitments = await _context.Appointments.Include(a => a.AppointmentStatus).ToListAsync();
                Appoitments = await _context.Appointments.Include(a => a.Service).ToListAsync();
                Appoitments = await _context.Appointments.ToListAsync();
            }
        }
    }
}
