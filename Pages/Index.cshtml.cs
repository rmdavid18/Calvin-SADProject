using Capstonep2.Infrastructure.Domain.Models;
using Capstonep2.Infrastructure.Domain;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Capstonep2.Infrastructure.Domain;
#pragma warning disable CS8602, CS8604

namespace Capstonep2.Pages
{
    public class IndexModel : PageModel
    {
        private ILogger<Index> _logger;
        private DefaultDBContext _context;

        [BindProperty]
        public ViewModel View { get; set; }



        [BindProperty]
        public List<IdValuePair>? SelectedCities { get; set; }
        public List<IdValuePair>? Cities {
            
            get
            {
                return new List<IdValuePair>() {
                        new IdValuePair() { Id = Guid.Parse("ab2f5505-74d1-4efd-9d81-dc28cad8620a"), Value = "Olongapo" },
                        new IdValuePair() { Id = Guid.Parse("ab2f5505-74d1-4efd-9d81-dc28cad8620b"), Value = "Dinalupihan" },
                        new IdValuePair() { Id = Guid.Parse("ab2f5505-74d1-4efd-9d81-dc28cad8620c"), Value = "Subic" },
                        new IdValuePair() { Id = Guid.Parse("ab2f5505-74d1-4efd-9d81-dc28cad8620d"), Value = "Castillejos" },
                        new IdValuePair() { Id = Guid.Parse("ab2f5505-74d1-4efd-9d81-dc28cad8620e"), Value = "San Antonio" },
                        new IdValuePair() { Id = Guid.Parse("ab2f5505-74d1-4efd-9d81-dc28cad8620f"), Value = "San Marcelino" },
                };
            }  
        }

        public IndexModel(DefaultDBContext context, ILogger<Index> logger)
        {
            _logger = logger;
            _context = context;
            View = View ?? new ViewModel();
            SelectedCities = SelectedCities ?? new List<IdValuePair>() { new IdValuePair() { Id = Guid.Parse("ab2f5505-74d1-4efd-9d81-dc28cad8620b"), Value = "Dinalupihan"} };
        }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (string.IsNullOrEmpty(View.Email))
            {
                ModelState.AddModelError("", "Login failed");
                return Page();
            }

            if (string.IsNullOrEmpty(View.Password))
            {
                ModelState.AddModelError("", "Login failed");
                return Page();
            }

            var user = _context?.Users?.FirstOrDefault(a => a.Email.ToLower() == View.Email.ToLower());

            if (user == null)
            {
                ModelState.AddModelError("", "Login failed");
                return Page();
            }
            else
            {
                var passwordInfo = _context?.UserLogins?.FirstOrDefault(a => a.UserID == user.ID && a.Key.ToLower() == "password");

                if (passwordInfo != null)
                {
                    if (BCrypt.Net.BCrypt.EnhancedVerify(View.Password, passwordInfo.Value))
                    {
                        var loginRetries = _context?.UserLogins?.FirstOrDefault(a => a.UserID == user.ID && a.Key.ToLower() == "loginretries");
                        if (loginRetries == null)
                        {
                            loginRetries = new UserLogin()
                            {
                                ID = Guid.NewGuid(),
                                UserID = user.ID,
                                Type = "General",
                                Key = "LoginRetries",
                                Value = "0"
                            };

                            _context?.UserLogins?.Add(loginRetries);
                            _context?.SaveChanges();
                        }

                        loginRetries.Value = "0";

                        _context?.UserLogins?.Update(loginRetries);
                        _context?.SaveChanges();


                        var isActive = _context?.UserLogins?.FirstOrDefault(a => a.UserID == user.ID && a.Key.ToLower() == "isactive");

                        if (isActive == null)
                        {
                            ModelState.AddModelError("", "Your account is inactive. Please talk to your administrator.");
                            return Page();
                        }
                        else
                        {

                            if (isActive.Value.ToLower() != "true")
                            {
                                ModelState.AddModelError("", "Your account is inactive. Please talk to your administrator.");
                                return Page();
                            }
                            else
                            {
                                var userRole = _context?.UserRoles?.Include(a => a.Role)!.FirstOrDefault(a => a.UserID == user.ID);

                                List<Claim> claims = new()

                                {
                                    new Claim(ClaimTypes.NameIdentifier, (user.ID ?? Guid.NewGuid()).ToString()),

                                    new Claim(ClaimTypes.Name, user.FirstName   ?? ""),
                                    new Claim(ClaimTypes.Role, userRole!.Role!.Name)
                                };

                                ClaimsPrincipal principal = new(new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme));

                                await HttpContext.SignInAsync(principal, new AuthenticationProperties()
                                {
                                    IsPersistent = true,
                                    ExpiresUtc = DateTime.Now.AddMinutes(30)
                                });
                                if (userRole!.Role!.Name.ToLower() == "admin")
                                {
                                    return RedirectPermanent("/manage/admin/dashboard");
                                }
                                else
                                {
                                    return RedirectPermanent("/manage/client/dashboard");
                                }

                            }
                        }
                    }
                    else
                    {

                    }
                }
            }


            return Page();
        }

        [HttpGet("cities")]
        public JsonResult? OnGetCities(int pageIndex = 1, string? keyword = "", int pageSize = 10)
        {
            return new JsonResult(Cities!.Select(a => new LookupDto.Result()
            {
                Id = a.Id.ToString(),
                Text = a.Value ?? ""
            })
            .AsQueryable()            
            .GetLookupPaged(pageIndex, pageSize));
        }

        public class ViewModel
        {
            public string? Email { get; set; }
            public string? Password { get; set; }
        }

        public class IdValuePair
        {
            public Guid? Id { get; set; }
            public string? Value { get; set; }
        }
    }
}