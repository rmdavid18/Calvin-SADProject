namespace Capstonep2.Infrastructure.Domain.Models
{
    public class ApptSevice
    {
        public Guid? Id { get; set; }
        public Guid? AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }
        public Guid? ServiceId { get; set; }
        public Service? Service { get; set; }
    }
}
