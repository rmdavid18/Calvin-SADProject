using Capstonep2.Infrastructure.Domain;
using Capstonep2.Infrastructure.Domain.Models;
using Capstonep2.Infrastructure.Domain.Models.Enums;
using Capstonep2.Infrastructure.Domain.Security;
using Capstonep2.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capstonep2.Pages.Manage.Admin
{
    [Authorize(Roles = "admin")]
    public class ViewClientModel : PageModel
    {
        private ILogger<Index> _logger;
        private DefaultDBContext _context;
        [BindProperty]
        public ViewModel View { get; set; }




        public ViewClientModel(DefaultDBContext context, ILogger<Index> logger)
        {
            _logger = logger;
            _context = context;
            View = View ?? new ViewModel();
        }
        public IActionResult OnGet(Guid? id = null, Guid? crid = null)
        {

            ViewData["id"] = id;
            var patient = _context?.Clients?.Where(a => a.ID == id).FirstOrDefault();
            if (patient != null)
            {


                ViewData["address"] = patient.Address;
                ViewData["birthdate"] = patient.BirthDate.ToString("dd/MM/yyyy");
                ViewData["firstname"] = patient.FirstName;
                ViewData["middlename"] = patient.MiddleName;
                ViewData["lastname"] = patient.LastName;
                ViewData["gender"] = patient.Gender;



                var apptsRecords = _context.Appointments?.Where(a => a.PatientID == id).ToList();
                View.Appointments = apptsRecords;


                

                var payments = _context?.Payments?.ToList();
                

                View.Findings = payments;
                




            }

            View.PatientID = id;
            return Page();
        }

        public void OnPostRecord()
        {

            Guid? newId = Guid.NewGuid();
            DateTime? endTime = View.StartTime.Value.AddHours(1);
            Appointment appointment = new Appointment()
            {
                ID = newId,
                PatientID = View.PatientID,
                Visit = Infrastructure.Domain.Models.Enums.Visit.WalkIn,
                StartTime = View.StartTime,
                EndTime = endTime,
                
                FDescription = View.PDesc,

            };
            _context?.Appointments?.Add(appointment);

            if (View.SList != null)
            {
                foreach (var symptom in View.SList)
                {


                    _context?.ApptSevices?.Add(new ApptSevice()
                    {
                        Id = Guid.NewGuid(),
                        AppointmentId = newId,
                        ServiceId = symptom

                    });




                }

            }

            if (View.VList != null)
            {
                foreach (var purpose in View.VList)
                {


                    _context?.ApptProviders?.Add(new ApptProvider()
                    {
                        Id = Guid.NewGuid(),
                        AppointmetId = newId,
                        ProviderId = purpose

                    });




                }

            }




         

            if (View.FList != null)
            {
                foreach (var finding in View.FList)
                {
                    _context?.ApptPayment.Add(new ApptPayment()
                    {
                        Id = Guid.NewGuid(),
                        AppointmentId = newId,
                        FindingId = finding,

                    });

                }
            }

            _context?.SaveChanges();

            OnGet(View.PatientID);
        }


        [HttpGet("purpose")]
        public JsonResult? OnGetPurpose(int pageIndex = 1, string? keyword = "", int pageSize = 10)
        {
            return new JsonResult(_context.Providers!.Select(a => new LookupDto.Result()
            {
                Id = a.Id.ToString(),
                Text = a.Name ?? ""
            })
            .AsQueryable()
            .GetLookupPaged(pageIndex, pageSize));
        }

        [HttpGet("symptom")]
        public JsonResult? OnGetSymptom(int pageIndex = 1, string? keyword = "", int pageSize = 10)
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
      





        public class ViewModel : UserViewModel
        {
            public Guid? PatientID { get; set; }
            public List<Guid>? SList { get; set; }
            public List<Guid>? VList { get; set; }
            public List<Guid>? FList { get; set; }
            public List<Guid>? PList { get; set; }
            public Guid? ApptId { get; set; }
            [ForeignKey("PatientID")]
            public Infrastructure.Domain.Models.Client? Client { get; set; }
            public List<Payment>? Findings { get; set; }
            
           
            public List<Appointment>? Appointments { get; set; }
            public List<Service>? Services { get; set; }
            public List<Infrastructure.Domain.Models.Provider>? Providers { get; set; }

            public string? FTags { get; set; }
            public string? FDescription { get; set; }

            public string? FDesc { get; set; }
            public string? PDesc { get; set; }
            public string? PTags { get; set; }
            public string? PDescription { get; set; }
            public DateTime? StartTime { get; set; }
            public DateTime? EndTime { get; set; }
            public string? Symptom { get; set; }

            public Infrastructure.Domain.Models.Enums.Status Status { get; set; }
           


        }

    }


}

