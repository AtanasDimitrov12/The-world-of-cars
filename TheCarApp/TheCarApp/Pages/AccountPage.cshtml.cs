using Entity_Layer;
using Manager_Layer;
using ManagerLayer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace TheCarApp.Pages
{
    [Authorize]
    public class AccountPageModel : PageModel
    {
        private ProjectManager _projectManager = new ProjectManager();  
        public User user { get; set; }
        public List<RentACar> rentals { get; set; }
        public string UserEmail { get; set; }

        public void OnGet()
        {
            UserEmail = User.Identity.Name;
            user = _projectManager.peopleManager.GetUser(UserEmail);
            

            //rentals.Add();
            
        }

        public async Task<IActionResult> OnPostLogout()
        {
            await HttpContext.SignOutAsync(); // This uses the default authentication scheme.
            return RedirectToPage("/Index"); // Redirect to the home page or login page after logout.
        }
    }
}


//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using ManagerLayer;
//using Entity_Layer;

//public class AccountModel : PageModel
//{
//    private readonly ProjectManager _projectManager;
//    public User User { get; set; }
//    public List<Rental> Rentals { get; set; }

//    public AccountModel(ProjectManager projectManager)
//    {
//        _projectManager = projectManager;
//    }

//    public void OnGet()
//    {
//        // Assuming we have a method to get user and rental data
//        User = _projectManager.peopleManager.GetUser(User.Identity.Name); // Adjust as per your user retrieval logic
//        Rentals = _projectManager.rentManager.GetRentalsForUser(User.Id);
//    }
//}
