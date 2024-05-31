using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity_Layer;
using Manager_Layer;
using Microsoft.AspNetCore.Authorization;
using EntityLayout;
using ManagerLayer;
using Entity_Layer.Enums;

namespace TheCarApp.Pages
{
    [Authorize]
    public class RentACarPageModel : PageModel
    {
        private readonly ProjectManager projectManager;

        public Car Car { get; set; }
        public User user { get; set; }
        public string UserEmail { get; set; }
        public decimal PriceResult { get; set; }
        public string ErrorMessage { get; set; }

        public RentACarPageModel(ProjectManager _projectManager)
        {
            projectManager = _projectManager;
        }

        public IActionResult OnGet(int carId)
        {
            Car = projectManager.CarManager.GetCarById(carId);

            if (Car == null)
            {
                return RedirectToPage("/NotFound");
            }
            else
            {
                // Record the view
                projectManager.CarManager.RecordCarView(carId);
            }
            UserEmail = User.Identity.Name;
            user = projectManager.PeopleManager.GetUser(UserEmail);

            return Page();
        }

        public IActionResult OnPostCalculatePrice(DateTime StartDate, DateTime EndDate)
        {
            Car = projectManager.CarManager.GetCarById(int.Parse(RouteData.Values["CarId"].ToString()));
            if (Car == null)
            {
                ErrorMessage = "Car not found.";
                return Page();
            }

            if (EndDate <= StartDate)
            {
                ErrorMessage = "End date must be after start date.";
                return Page();
            }

            try
            {
                PriceResult = projectManager.RentManager.CalculatePrice(Car.PricePerDay, StartDate, EndDate);
                ErrorMessage = null;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine("Error in OnPostCalculatePrice: " + ex.Message);
                ErrorMessage = "An error occurred while calculating the price.";
            }

            return Page();
        }

        public IActionResult OnPostRentCar(DateTime StartDate, DateTime EndDate)
        {
            Car = projectManager.CarManager.GetCarById(int.Parse(RouteData.Values["CarId"].ToString()));
            if (Car == null)
            {
                ErrorMessage = "Car not found.";
                return Page();
            }

            if (EndDate <= StartDate)
            {
                ErrorMessage = "End date must be after start date.";
                return Page();
            }

            user = projectManager.PeopleManager.GetUser(User.Identity.Name);

            try
            {
                RentACar rentACar = new RentACar(user, Car, StartDate, EndDate, RentStatus.REQUESTED);
                projectManager.RentManager.RentACar(rentACar);
                PriceResult = projectManager.RentManager.CalculatePrice(Car.PricePerDay, StartDate, EndDate);
                ErrorMessage = null;
                return RedirectToPage("RentConfirmation", new { carId = Car.Id, rent = rentACar});
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine("Error in OnPostRentCar: " + ex.Message);
                ErrorMessage = "An error occurred while renting the car.";
            }

            return Page();
        }
    }
}
