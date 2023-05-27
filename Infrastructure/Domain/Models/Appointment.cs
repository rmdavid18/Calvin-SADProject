using System.ComponentModel.DataAnnotations.Schema;

namespace Capstonep2.Infrastructure.Domain.Models
{
    public class Appointment
    {
        public Guid? ID { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        
        
        public Guid? PatientID { get; set; }
        public Enums.Status Status { get; set; }
        public Enums.Visit Visit { get; set; }

        public string? FDescription { get; set; }
       

        [ForeignKey("PatientID")]
        public Client? Client { get; set; }


        public ICollection<Service>? Services { get; set; }
        public ICollection<Provider>? Providers { get; set; }

        public ICollection<Payment>? Findings { get; set; }
       
    }
}