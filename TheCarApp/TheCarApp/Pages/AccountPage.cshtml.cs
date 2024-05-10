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
            await HttpContext.SignOutAsync(); 
            return RedirectToPage("/Index"); 
        }
    }
}