using Microsoft.AspNetCore.Mvc;
using System;

using Microsoft.CodeAnalysis;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Service_App.Models
{
    public class Appointments
    {
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Car Make")]
        public string CarMake { get; set; }

        [Display(Name = "Car Model")]
        public string CarModel { get; set; }
        [Display(Name = "Car Plates")]
        public string CarPlate { get; set; }

        [Display(Name = "Car Year")]
        public int CarYear { get; set; }

        [Display(Name = "Additional Info")]
        public string Additionalinfo { get; set; }

        [Display(Name = "Appointment Date")]
        public DateTime AppointmentDate { get; set; }
        public string? UniqueCode {  get; set; }
        public int ServiceId { get; set; }
        [BindNever]
        public Services? Service { get; set; }
 
        public int? StatusId { get; set; }
        public AppointmentStatus? AppointmentStatus { get; set; }

      

    }
}
