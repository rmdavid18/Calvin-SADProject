using Capstonep2.Infrastructure.Domain.Models;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Capstonep2.ViewModel
{
    public class CRViewModel
    {
        public Infrastructure.Domain.Models.Enums.Status StatusEdit { get; set; }
        public Guid? ConsultationRecordID { get; set; }
        public Guid? PatientID { get; set; }
        public List<string>? SymptomsList { get; set; }
        public List<string>? PurposesList { get; set; }
        public List<string>? PaymentList { get; set; }
        public List<string>? PrescriptionsList { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Guid? FindingID { get; set; }
        public string? FTags { get; set; }
        public string? FDescription { get; set; }
        public Guid? PrescriptionID { get; set; }
        public string? PTags { get; set; }
        public string? PDescription { get; set; }
        public Client? Client { get; set; }
        public List<Guid>? SymptomsEdit { get; set; }
        public List<Guid>? PurposesEdit {  get; set; }
        public Guid? ApptId { get; set; }
        public Guid ? EditId { get; set; }
        public string? FDesc { get; set; }
        public string? PDesc { get; set; }
        public List<Guid>? FList { get; set; }
        public List<Guid>? PList { get; set; }
        public Appointment? Appointment { get; set; }
       
        public List<Payment>? Payments { get; set; }
        public List<Service>? Serbisyo { get; set; }
        public List<Provider>? Tao { get; set; }
        public List<Appointment>? Appointments { get; set; }
        public List<Infrastructure.Domain.Models.Client>? Clients { get; set; }
        public string? AppointmentId { get; set; }

        public List<Service>? CServices { get; set; }
        public List<Provider>? CProviders { get; set; }
        public Infrastructure.Domain.Models.Client? Kliyente { get; set; }
    }
}
