using ManagerLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity_Layer;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace TheCarApp.Pages
{
    [AllowAnonymous]
    public class SignUpPageModel : PageModel
    {
        private ProjectManager _projectManager = new ProjectManager();

        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string LicenseNumber{ get; set; }

        public SignUpPageModel()
        {
            _projectManager = new ProjectManager();
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostSignUp()
        {
            if (!ModelState.IsValid)
            {
                return Page(); 
            }

            var newUser = new User(0, Email,Password, Username, DateTime.Now, int.Parse(LicenseNumber), null);
            _projectManager.PeopleManager.AddPerson(newUser); 
            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Email)
                };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            return RedirectToPage("/MarketPlace");
        }



        public async Task<IActionResult> OnPostLogin()
        {
            if (Email != null && Password != null)
            {
                if (_projectManager.PeopleManager.AuthenticateUser(Email.ToLower(), Password))
                {
                    var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, Email.ToLower())
                };

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(30)
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);

                    return RedirectToPage("/MarketPlace");
                }
                else
                {
                    ModelState.AddModelError("", "Login failed. Please check your email and password.");
                    return Page();
                }
            }
            else 
            {
                ModelState.AddModelError("", "Login failed. Please check your email and password.");
                return Page();
            }
        }
    }
}
