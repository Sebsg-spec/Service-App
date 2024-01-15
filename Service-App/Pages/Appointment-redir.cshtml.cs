using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Service_App.Data;
using Service_App.Models;
using System.Linq;
using System;
using Service_App.Pages.Appointment;

namespace Service_App.Pages
{
public class Appointment_redirModel : PageModel
    {
    [BindProperty]
    public string UniqueCode { get; set; }
        public Appointments Appointment { get; set; }
        public string Status { get; set; }
        public string FullName { get; set; }
        public string CarMake { get; set; }
        public string CarModel { get; set; }
        public string CarPlate { get; set; }
        public int CarYear { get; set; }
        public string Additionalinfo { get; set; }
        public DateTime AppointmentDate { get; set; }

        private readonly Service_AppContext _context;

        public Appointment_redirModel(Service_AppContext context)
        {
            _context = context;
        }
    public void OnGet()
    {
        // This method is executed when the page is initially requested.
    }

    public IActionResult OnPost()
    {
        // Check if UniqueCode is provided
        if (string.IsNullOrEmpty(UniqueCode))
        {
            ModelState.AddModelError("UniqueCode", "Please enter a Unique Code.");
            return Page();
        }

        // Retrieve the appointment with the provided UniqueCode
        var appointment = _context.AppointmentStatus
            .FirstOrDefault(a => a.UniqueCode == UniqueCode);

        if (appointment != null)
        {

                // Retrieve and set the Status
                Status = appointment.Status;
                
            }
        else
        {
            // Handle the case where no appointment is found
            ModelState.AddModelError("UniqueCode", "No appointment found with the provided Unique Code.");
        }

        return Page();
    }
}

}

