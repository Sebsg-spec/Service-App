using System;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Service_App.Data;
using Service_App.Models;

namespace Service_App.Pages.Appointment
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly Service_AppContext _context;

        public CreateModel(Service_AppContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Appointments Appointment { get; set; }

        public SelectList LocationsList { get; set; }

        public IActionResult OnGet()
        {
            // Fetch locations from the database and populate the dropdown
            LocationsList = new SelectList(_context.Services, "Id", "Location");
            return Page();
        }
        public string GenerateRandomCode()
        {
            Random rand = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[rand.Next(s.Length)]).ToArray());
        }
        public IActionResult OnPost()
        {
            string uniqueCode = GenerateRandomCode();

            // Create a new AppointmentStatus object
            var appointmentStatus = new AppointmentStatus
            {
                UniqueCode = uniqueCode,
                AppointmentId = Appointment.Id,
                Status = "Pending"
            };

            Appointment.UniqueCode = uniqueCode;
            // Add the AppointmentStatus to the context and save changes
            _context.AppointmentStatus.Add(appointmentStatus);
            _context.SaveChanges();

            // Fetch the newly created AppointmentStatus from the database
            var newlyCreatedStatus = _context.AppointmentStatus.Single(a => a.UniqueCode == uniqueCode);

            // Set the StatusId of the Appointment to the newly created StatusId
            Appointment.StatusId = newlyCreatedStatus.Id;

            // Check if an appointment already exists for the selected date
            if (_context.Appointments.Any(a => a.AppointmentDate == Appointment.AppointmentDate))
            {
                ModelState.AddModelError("Appointment.AppointmentDate", "An appointment already exists for this date.");
                return RedirectToPage("/Appointment/Index");
            }

            // Set the generated code for the current appointment

            // Add the Appointment to the context and save changes
            _context.Appointments.Add(Appointment);
            _context.SaveChanges();

            ViewData["AppointmentCode"] = uniqueCode;

            return Page();
        }

    }
}
