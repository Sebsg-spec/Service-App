using System.ComponentModel.DataAnnotations;

namespace Service_App.Models
{
    public class AppointmentStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        [Display(Name = "Unique Code")]
        public string UniqueCode { get; set; }
        public int AppointmentId { get; set; }
        public Appointments Appointments { get; set; }
    }
}
