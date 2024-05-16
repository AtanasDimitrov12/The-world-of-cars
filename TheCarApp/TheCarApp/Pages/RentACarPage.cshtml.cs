using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity_Layer;
using Manager_Layer;
using Microsoft.AspNetCore.Authorization;
using Entity_Layer;
using EntityLayout;
using ManagerLayer;
using Microsoft.AspNetCore.Identity;
using InterfaceLayer;

namespace TheCarApp.Pages
{
    [Authorize]
    public class RentACarPageModel : PageModel
    {
        private readonly ProjectManager projectManager;

        public Car Car { get; set; }
        public User user { get; set; }
        public string UserEmail { get; set; }
        public decimal PricePerDay { get; set; }

        public RentACarPageModel(ProjectManager _projectManager)
        {
            projectManager = _projectManager;
        }
    

        public void OnGet(int carId)
        {
            Car = projectManager.carManager.GetCarById(carId);
            PricePerDay = Car.PricePerDay;
            if (Car == null)
            {
                RedirectToPage("/NotFound");
            }
            else
            {
                // Record the view
                projectManager.carManager.RecordCarView(carId);
            }
            UserEmail = User.Identity.Name;
            user = projectManager.peopleManager.GetUser(UserEmail);
        }



        public IActionResult OnPostSubmitRental(DateTime startDate, DateTime endDate)
        {
            if (user == null || Car == null)
            {
                return new JsonResult(new { success = false, message = "User or car not found." });
            }
            if (endDate <= startDate)
            {
                return new JsonResult(new { success = false, message = "End date must be after start date." });
            }
            try
            {
                projectManager.rentManager.RentACar(user, Car, startDate, endDate);
                var data = new { success = true, message = "Success" };
                return new JsonResult(data);
            }
            catch (Exception ex)
            {
                return new JsonResult(new { success = false, message = ex.Message });
            }
        }
    }
}
