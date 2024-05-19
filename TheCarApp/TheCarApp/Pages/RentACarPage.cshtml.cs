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
using ManagerLayer.Strategy;

namespace TheCarApp.Pages
{
    [Authorize]
    public class RentACarPageModel : PageModel
    {
        private readonly ProjectManager projectManager;

        public Car Car { get; set; }
        public User user { get; set; }
        public string UserEmail { get; set; }
        public decimal Price { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public RentACarPageModel(ProjectManager _projectManager)
        {
            projectManager = _projectManager;
        }
    

        public void OnGet(int carId)
        {
            Car = projectManager.CarManager.GetCarById(carId);
            
            if (Car == null)
            {
                RedirectToPage("/NotFound");
            }
            else
            {
                // Record the view
                projectManager.CarManager.RecordCarView(carId);
            }
            UserEmail = User.Identity.Name;
            user = projectManager.PeopleManager.GetUser(UserEmail);
        }



        public IActionResult OnPostSubmitRental()
        {
            var startDateString = Request.Form["hiddenStartDate"];
            var endDateString = Request.Form["hiddenEndDate"];

            if (DateTime.TryParse(startDateString, out DateTime startDate) && DateTime.TryParse(endDateString, out DateTime endDate))
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
                    projectManager.RentManager.RentACar(user, Car, startDate, endDate);
                    var data = new { success = true, message = "Success" };
                    return new JsonResult(data);
                }
                catch (Exception ex)
                {
                    return new JsonResult(new { success = false, message = ex.Message });
                }
            }
            else
            {
                return new JsonResult(new { success = false, message = "Invalid dates provided." });
            }
        }

        public IActionResult OnPostCalculatePrice()
        {
            var startDateString = Request.Form["hiddenStartDate"];
            var endDateString = Request.Form["hiddenEndDate"];

            if (DateTime.TryParse(startDateString, out DateTime startDate) && DateTime.TryParse(endDateString, out DateTime endDate))
            {
                if (endDate <= startDate)
                {
                    ModelState.AddModelError("", "End date must be after start date.");
                    return Page();
                }

                Start = startDate;
                End = endDate;
                Price = projectManager.RentManager.CalculatePrice(Car.PricePerDay, Start, End);

                TempData["TotalPrice"] = Price;
                return Page();
                //return RedirectToPage("/RentACarPage/" + Car.Id);
            }
            else
            {
                ModelState.AddModelError("", "Invalid dates provided.");
                return Page();
            }
        }

    }
}
