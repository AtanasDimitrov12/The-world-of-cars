using Entity_Layer;
using Manager_Layer;
using ManagerLayer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
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
        [BindProperty]
        public IFormFile ProfilePicture { get; set; }


        public void OnGet()
        {
            UserEmail = User.Identity.Name;
            user = _projectManager.PeopleManager.GetUser(UserEmail);

            rentals = _projectManager.RentManager.rentalHistory
                   .Where(rental => rental.user.Id == user.Id)
                   .ToList();

            Rentals = _projectManager.RentManager.rentalHistory
                   .Where(rental => rental.user.Id == user.Id && rental.RentStatus != Entity_Layer.Enums.RentStatus.CANCELLED && rental.RentStatus != Entity_Layer.Enums.RentStatus.REQUESTED)
                   .ToList().Count;


        }

        public async Task<IActionResult> OnPostUploadProfilePicture()
        {
            UserEmail = User.Identity.Name;
            user = _projectManager.PeopleManager.GetUser(UserEmail);

            if (ProfilePicture != null && ProfilePicture.Length > 0)
            {
                var fileName = Path.GetFileName(ProfilePicture.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pictures", "profile_pictures", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ProfilePicture.CopyToAsync(fileStream);
                }

                var relativeFilePath = $"/pictures/profile_pictures/{fileName}";

                _projectManager.UserRepository.UploadProfilePicture(user, relativeFilePath);
            }

            return RedirectToPage();
        }


        public async Task<IActionResult> OnPostLogout()
        {
            await HttpContext.SignOutAsync(); 
            return RedirectToPage("/Index"); 
        }
    }
}