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
        private ProjectManager _projectManager;

        [BindProperty]
        [Required(ErrorMessage = "Username is required.")]
        [StringLength(10, ErrorMessage = "Username cannot be longer than 10 characters.")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Driving license number is required.")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Driving license number must be exactly 9 digits.")]
        public string LicenseNumber { get; set; }

        public SignUpPageModel(ProjectManager pm)
        {
            _projectManager = pm;
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

            var newUser = new User(0, Email, Password, Username, DateTime.Now, int.Parse(LicenseNumber), null, "/pictures/profile_pictures/blank-profile-picture.jpg");
            if (_projectManager.PeopleManager.AddPerson(newUser, out string ErrorMessage))
            {
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
            else
            {
                ModelState.AddModelError("", ErrorMessage);
                return Page();
            }
        }



        public async Task<IActionResult> OnPostLogin()
        {
            if (Email != null && Password != null)
            {
                if (_projectManager.PeopleManager.AuthenticateUser(Email.ToLower(), Password, out string Errormessage))
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
