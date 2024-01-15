using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Service_App.Data;
using Service_App.Models;

namespace Service_App.Pages
{
    public class MyAppointmentsModel : PageModel
    {
        private readonly Service_AppContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        public MyAppointmentsModel(Service_AppContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public List<Appointments> UserAppointments { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            // Get the current logged-in user
            var currentUser = await _userManager.GetUserAsync(User);


            return Page();
        }
    }
}
