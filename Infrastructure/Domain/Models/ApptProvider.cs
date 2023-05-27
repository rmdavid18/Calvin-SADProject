namespace Capstonep2.Infrastructure.Domain.Models
{
    public class ApptProvider
    {
        public Guid? Id { get; set; }
        public Guid? ProviderId { get; set; }
        public Guid? AppointmetId { get; set; }
        public Appointment? Appointment { get; set; }
        public Provider? Provider { get; set; }
    }
}
