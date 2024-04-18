using ManagerLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity_Layer;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

namespace TheCarApp.Pages
{
    [AllowAnonymous]
    public class SignUpPageModel : PageModel
    {
        private ProjectManager _projectManager = new ProjectManager(); // Use a readonly field for the injected service

        [BindProperty]
        public User newUser { get; set; }

        [BindProperty]
        public User LogInUser { get; set; }

        public SignUpPageModel()
        {
            // Constructor remains empty if no services are injected directly
        }

        public void OnGet()
        {
            // Intentionally left empty for demonstration
        }

        public async Task<IActionResult> OnPostSignUp()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Return the same page to display validation errors
            }

            newUser.CreatedOn = DateTime.Now; // Set the CreatedOn date here
            // Implement user creation logic
            _projectManager.peopleManager.AddPerson(newUser); // Assuming AddPerson handles null checks

            // Create and sign in the user
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, newUser.email)
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

            return RedirectToPage("/MarketPlace"); // Redirect to a confirmation page or the home page
        }

        public async Task<IActionResult> OnPostLogIn()
        {
            if (_projectManager.peopleManager.AuthenticateUser(LogInUser))
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, LogInUser.email)
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
    }
}
