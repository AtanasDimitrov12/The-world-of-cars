using ManagerLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity_Layer;

namespace TheCarApp.Pages
{
    public class SignUpPageModel : PageModel
    {
        private ProjectManager _projectManager = new ProjectManager(); // Use a readonly field for the injected service

        [BindProperty]
        public User newUser { get; set; }

        [BindProperty]
        public User LogInUser { get; set; }

        public SignUpPageModel()
        {
            // Injected via constructor
        }

        public void OnGet()
        {
            // This is where you would prepare any data needed for the GET request  
        }

        public IActionResult OnPostSignUp()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // Return the same page to display validation errors
            }

            newUser.CreatedOn = DateTime.Now; // Set the CreatedOn date here

            _projectManager.LoadAllData();
            _projectManager.peopleManager.AddPerson(newUser); // Assuming AddPerson handles null checks
            return RedirectToPage("/MarketPlace"); // Redirect to a confirmation page or the home page
        }

        public IActionResult OnPostLogIn()
        {
            _projectManager.LoadAllData();
            bool isAuthenticated = _projectManager.peopleManager.AuthenticateUser(LogInUser);
            if (isAuthenticated)
            {
                return RedirectToPage("/MarketPlace");
            }
            else
            {
                ModelState.AddModelError("", "Login failed. Please check your username and password.");
                return Page();
            }
        }
    }
}
