using Capstonep2.Infrastructure.Domain;
using Capstonep2.Infrastructure.Domain.Models;
using Capstonep2.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Capstonep2.Pages.Manage.Patient
{
    [Authorize(Roles = "patient")]
    public class PViewDetailsModel : PageModel
    {

        private ILogger<System.Index> _logger;
        private DefaultDBContext _context;

        [BindProperty]
        public ViewModel View { get; set; }

        public PViewDetailsModel(DefaultDBContext context, ILogger<System.Index> logger)
        {
            _logger = logger;
            _context = context;
            View = View ?? new ViewModel();
        }



        public void OnGet(Guid? ID = null)
        {
            var appointment = _context?.Appointments?.Where(a => a.ID == ID).Include(a => a.Client).FirstOrDefault();
            if (appointment != null) { View.Appointment = appointment; }

            var apptSymptoms = _context?.ApptSevices?.Where(a => a.AppointmentId == ID).ToList(); //Get ApptSymptomList
            var apptPurposes = _context?.ApptProviders?.Where(a => a.AppointmetId == ID).ToList();
            var apptFindings = _context?.ApptPayment?.Where(a => a.AppointmentId == ID).ToList();
            

            List<string?> symptomList = new List<string?>(); //Declare symptom list
            List<string?> purposeList = new List<string?>();
            List<string?> findingList = new List<string?>();
           


            Service symptom = new Service();
            Provider purpose = new Provider();
            Payment finding = new Payment();
           



            if (appointment != null)
            {
                View.Appointment = appointment;


                foreach (var item in apptSymptoms) //For each matching symptom
                {
                    symptom = _context?.Services?.Where(a => a.Id == item.ServiceId).FirstOrDefault(); //Get Symptoms
                    if (symptom != null)
                    {
                        symptomList.Add(symptom.Name);
                    }
                }

                foreach (var item in apptPurposes)
                {
                    purpose = _context?.Providers?.Where(a => a.Id == item.ProviderId).FirstOrDefault();
                    if (purpose != null)
                    {
                        purposeList.Add(purpose.Name);
                    }

                }

                foreach (var item in apptFindings)
                {
                    finding = _context?.Payments?.Where(a => a.ID == item.FindingId).FirstOrDefault();
                    if (finding != null)
                    {
                        findingList.Add(finding.FName);
                    }
                }

               


                View.SymptomsList = symptomList;
                View.PurposesList = purposeList;
                View.PaymentList = findingList;
               

            }
            View.ApptId = ID;
        }

        public void OnPostApptsedit()
        {
            
            var appointment = _context?.Appointments?.Where(a => a.ID == View.ApptId).FirstOrDefault();
            if (appointment != null)
            {
                var apptSymptoms = _context?.ApptSevices.Where(a=> a.AppointmentId == View.ApptId).ToList();
                var apptPurposes = _context?.ApptProviders.Where(a => a.AppointmetId == View.ApptId).ToList();

                _context?.ApptSevices.RemoveRange(apptSymptoms);
                _context?.ApptProviders.RemoveRange(apptPurposes);
                if (View.PurposesEdit != null)
                {
                    foreach (var purpose in View.PurposesEdit)
                    {


                        _context?.ApptProviders?.Add(new ApptProvider()
                        {
                            Id = Guid.NewGuid(),
                            AppointmetId = View.ApptId,
                            ProviderId = purpose
                        });




                    }

                }


                if (View.PurposesEdit != null)
                {
                    foreach (var symptom in View.SymptomsEdit)
                    {
                        _context.ApptSevices?.Add(new ApptSevice()
                        {
                            Id = Guid.NewGuid(),
                            AppointmentId = View.ApptId,
                            ServiceId = symptom
                        });


                    }
                }
                _context.SaveChanges();
                OnGet(View.ApptId);
            }

        }
        public void OnPostCanceled()
        {
            var status = _context?.Appointments?.FirstOrDefault(a=> a.ID == View.ApptId);
            if (status != null)
            {
                status.Status = Infrastructure.Domain.Models.Enums.Status.Cancelled;
                _context?.Appointments.Update(status);
            }
            OnGet(View.ApptId);

        }

        [HttpGet("purposeedit")]
        public JsonResult? OnGetPurposeedit(int pageIndex = 1, string? keyword = "", int pageSize = 10)
        {
            return new JsonResult(_context.Providers!.Select(a => new LookupDto.Result()
            {
                Id = a.Id.ToString(),
                Text = a.Name ?? ""
            })
            .AsQueryable()
            .GetLookupPaged(pageIndex, pageSize));
        }

        [HttpGet("symptomedit")]
        public JsonResult? OnGetSymptomedit(int pageIndex = 1, string? keyword = "", int pageSize = 10)
        {
            return new JsonResult(_context.Services!.Select(a => new LookupDto.Result()
            {
                Id = a.Id.ToString(),
                Text = a.Name ?? ""
            })
            .AsQueryable()
            .GetLookupPaged(pageIndex, pageSize));
        }

        public class ViewModel : CRViewModel
        {
            public Appointment Appointment { get; set; }
            public List<Service>? Services { get; set; }
            public List <Infrastructure.Domain.Models.Client>? Client { get; set; }
            public List<Provider>? Providers { get; set; }
            public List<Appointment>? Appointments { get; set; }
            public string? AppointmentId { get; set; }
            public List<Payment>? Findings { get; set; }
        
           
            public Infrastructure.Domain.Models.Client? Kliyente { get; set; }
            
        }
    }
}
