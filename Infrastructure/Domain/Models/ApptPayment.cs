namespace Capstonep2.Infrastructure.Domain.Models
{
    public class ApptPayment
    {
        public Guid? Id { get; set; }
        public Guid? AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }
        public Guid? FindingId { get; set; }
        public Payment? Finding { get; set; }
    }
}
