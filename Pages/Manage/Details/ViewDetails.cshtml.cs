using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore;
using Capstonep2.Infrastructure.Domain;
using Capstonep2.Infrastructure.Domain.Models;
using Capstonep2.ViewModel;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace Capstonep2.Pages.Manage.Consultation
{
    [Authorize(Roles = "admin")]
    public class ViewDetailsModel : PageModel
    {
        private ILogger<System.Index> _logger;
        private DefaultDBContext _context;

        [BindProperty]
        public ViewModel View { get; set; }

        public ViewDetailsModel(DefaultDBContext context, ILogger<System.Index> logger)
        {
            _logger = logger;
            _context = context;
            View = View ?? new ViewModel();
        }

        public void AppointmentModel(Guid? id = null)
        {
            var appointment = _context?.Appointments?.Where(a => a.ID == id).Include(a => a.Client).FirstOrDefault();


            var apptSymptoms = _context?.ApptSevices?.Where(a => a.AppointmentId == id).ToList(); //Get ApptSymptomList
            var apptPurposes = _context?.ApptProviders?.Where(a => a.AppointmetId == id).ToList();
            var apptFindings = _context?.ApptPayment?.Where(a => a.AppointmentId == id).ToList();
 

            List<string?> symptomList = new List<string?>(); //Declare symptom list
            List<string?> purposeList = new List<string?>();
            List<string?> findingList = new List<string?>();
            List<string?> prescriptionList = new List<string?>();

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

                foreach(var item in apptPurposes)
                {
                    purpose = _context?.Providers?.Where(a => a.Id == item.ProviderId).FirstOrDefault();
                    if (purpose != null)
                    {
                        purposeList.Add(purpose.Name);
                    }

                }

                foreach(var item in apptFindings)
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
        }


        public void OnGet(Guid? id = null, Guid? crid = null)

        {
            Guid? apptID = id;
            AppointmentModel(apptID);
            View.ApptId = apptID;
        }
        public void OnPostAddConsul()
        {
            
            

            
            var appt = _context?.Appointments?.Where(a => a.ID == View.ApptId).FirstOrDefault();

  
                appt.FDescription = View.FDesc;
            appt.Status = Infrastructure.Domain.Models.Enums.Status.Completed;
                
                _context?.Appointments?.Update(appt);




         

            if (View.FList != null)
            {
                foreach (var finding in View.FList)
                {
                    _context.ApptPayment.Add(new ApptPayment()
                    {
                        Id = Guid.NewGuid(),
                        AppointmentId = View.ApptId,
                        FindingId = finding
                    });

                }
            }



            
            _context?.SaveChanges();
            AppointmentModel(View.ApptId);
        }
        public void OnPostEditstatus()
        {
            
            var appointment = _context?.Appointments?.Where(a => a.ID == View.ApptId).FirstOrDefault();
            if (appointment != null)
            {
                appointment.Status = View.StatusEdit;
                _context?.Appointments.Update(appointment);
            }
            AppointmentModel(View.ApptId);
            _context.SaveChanges();

        }
        public void OnPostUpdate()
        {

            var appointment = _context?.Appointments?.Where(a => a.ID == View.ApptId).FirstOrDefault();
            if (appointment != null)
            {

                appointment.StartTime = View.StartTime;
                appointment.EndTime = View.StartTime.AddHours(1);

                var apptSymptoms = _context?.ApptSevices.Where(a => a.AppointmentId == View.ApptId).ToList();
                var apptPurposes = _context?.ApptProviders.Where(a => a.AppointmetId == View.ApptId).ToList();

                _context?.Appointments.Update(appointment);

                if (apptSymptoms != null && apptPurposes != null)
                {
                    _context?.ApptSevices.RemoveRange(apptSymptoms);
                    _context?.ApptProviders.RemoveRange(apptPurposes);
                }
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


                if (View.SymptomsEdit != null)
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
                
            }
            AppointmentModel(View.ApptId);
        }

        [HttpGet("dahilan")]
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

        [HttpGet("sintomas")]
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
   

        [HttpGet("finding")]
        public JsonResult? OnGetFinding(int pageIndex = 1, string? keyword = "", int pageSize = 10)
        {
            return new JsonResult(_context.Payments!.Select(a => new LookupDto.Result()
            {
                Id = a.ID.ToString(),
                Text = a.FName ?? ""


            })
            .AsQueryable()
            .GetLookupPaged(pageIndex, pageSize));
        }

        [HttpGet("dahilanedit")]
        public JsonResult? OnGetDahilanEdit(int pageIndex = 1, string? keyword = "", int pageSize = 10)
        {
            return new JsonResult(_context.Providers!.Select(a => new LookupDto.Result()
            {
                Id = a.Id.ToString(),
                Text = a.Name ?? ""


            })
            .AsQueryable()
            .GetLookupPaged(pageIndex, pageSize));
        }
        [HttpGet("sintomasedit")]
        public JsonResult? OnGetSintomasEdit(int pageIndex = 1, string? keyword = "", int pageSize = 10)
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

        }
    }

}
