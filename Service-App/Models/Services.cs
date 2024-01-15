using System.ComponentModel.DataAnnotations;
using System.Numerics;

namespace Service_App.Models
{
    public class Services
    {
     [Key]   public int Id { get; set; }
        public string Location { get; set; }
        public string Availability {  get; set; }
        public int Price {  get; set; }
    }
}
