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
        public int Rentals { get; set; }

        public void OnGet()
        {
            UserEmail = User.Identity.Name;
            user = _projectManager.PeopleManager.GetUser(UserEmail);

            rentals = _projectManager.RentManager.rentalHistory
                   .Where(rental => rental.user.Id == user.Id)
                   .ToList();

            Rentals = rentals.Count;


        }

        public async Task<IActionResult> OnPostLogout()
        {
            await HttpContext.SignOutAsync(); 
            return RedirectToPage("/Index"); 
        }
    }
}