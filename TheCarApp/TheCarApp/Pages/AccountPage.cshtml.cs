using Entity_Layer;
using Manager_Layer;
using ManagerLayer;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace TheCarApp.Pages
{
    [Authorize]
    public class AccountPageModel : PageModel
    {
        private readonly ProjectManager _projectManager;
        public User user { get; set; } = new User();
        public List<RentACar> rentals { get; set; } = new List<RentACar>();
        public string UserEmail { get; set; }
        public int Rentals { get; set; }
        [BindProperty]
        public IFormFile ProfilePicture { get; set; }
        [BindProperty]
        public string NewUsername { get; set; }
        [BindProperty]
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string NewPassword { get; set; }
        [BindProperty]
        public string ConfirmPassword { get; set; }

        public AccountPageModel(ProjectManager pm)
        {
            _projectManager = pm;
        }

        public void OnGet()
        {
            UserEmail = User.Identity.Name;
            user = _projectManager.PeopleManager.GetUser(UserEmail);

            if (user != null)
            {
                rentals = _projectManager.RentManager.RentalHistory
                    .Where(rental => rental.user != null && rental.user.Id == user.Id)
                    .ToList();

                Rentals = rentals
                    .Count(rental => rental.RentStatus != Entity_Layer.Enums.RentStatus.CANCELLED && rental.RentStatus != Entity_Layer.Enums.RentStatus.REQUESTED);
            }
            else
            {
                Rentals = 0;
            }
        }

        public async Task<IActionResult> OnPostUploadProfilePicture()
        {
            UserEmail = User.Identity.Name;
            user = _projectManager.PeopleManager.GetUser(UserEmail);

            if (ProfilePicture != null && ProfilePicture.Length > 0)
            {
                var fileName = Path.GetFileName(ProfilePicture.FileName);
                var fileExtension = Path.GetExtension(fileName).ToLower();

                var allowedExtensions = new[] { ".png", ".jpg", ".jpeg" };
                if (!allowedExtensions.Contains(fileExtension))
                {
                    ModelState.AddModelError(string.Empty, "Only PNG, JPG, and JPEG files are allowed.");
                    return Page();
                }

                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "pictures", "profile_pictures", fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await ProfilePicture.CopyToAsync(fileStream);
                }

                var relativeFilePath = $"/pictures/profile_pictures/{fileName}";

                _projectManager.UserRepository.UploadProfilePicture(user, relativeFilePath, out string Errormessage);
            }

            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostLogout()
        {
            await HttpContext.SignOutAsync();
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostEditCredentials()
        {
            UserEmail = User.Identity.Name;
            user = _projectManager.PeopleManager.GetUser(UserEmail);

            if (user != null)
            {
                if (!string.IsNullOrEmpty(NewUsername) && !_projectManager.PeopleManager.GetAllUsers().Any(u => u.Username == NewUsername && u.Id != user.Id))
                {
                    user.Username = NewUsername;
                }
                else
                {
                    ModelState.AddModelError("NewUsername", "Username is already taken.");
                    return Page();
                }

                if (!string.IsNullOrEmpty(NewPassword) && NewPassword == ConfirmPassword && NewPassword.Length >= 8)
                {
                    var (hash, salt) = _projectManager.PeopleManager.HashPassword(NewPassword);
                    user.Password = hash;
                    user.PassSalt = salt;
                }
                else
                {
                    ModelState.AddModelError("NewPassword", "Password does not meet the requirements or does not match the confirmation.");
                    return Page();
                }

                _projectManager.PeopleManager.UpdatePerson(user, out string errorMessage);
            }

            return RedirectToPage();
        }
    }
}
