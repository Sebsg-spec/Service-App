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
    public class IndexModel : PageModel
    {
        private readonly Service_App.Data.Service_AppContext _context;

        public IndexModel(Service_App.Data.Service_AppContext context)
        {
            _context = context;
        }

        public IList<AppointmentStatus> AppointmentStatus { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.AppointmentStatus != null)
            {

               
                    if (_context.AppointmentStatus != null)
                    {
                        AppointmentStatus = await _context.AppointmentStatus
                            .Include(a => a.Appointments)
                            .ToListAsync();
                    }
                


                AppointmentStatus = await _context.AppointmentStatus
                .Include(a => a.Appointments).ToListAsync();
            }
        }
    }
}
