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
        public List<RentACar> RentedPeriods { get; set; }

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
                projectManager.CarManager.RecordCarView(carId, out string ErrorMessage);
                RentedPeriods = projectManager.RentManager.GetRentedPeriods(carId);
            }
            UserEmail = User.Identity.Name;
            user = projectManager.PeopleManager.GetUser(UserEmail);

            return Page();
        }

        public JsonResult OnPostCalculatePrice(DateTime StartDate, DateTime EndDate)
        {
            Car = projectManager.CarManager.GetCarById(int.Parse(RouteData.Values["CarId"].ToString()));
            if (Car == null)
            {
                ErrorMessage = "Car not found.";
                return new JsonResult(new { errorMessage = "Car not found." });
            }

            if (EndDate <= StartDate)
            {
                ErrorMessage = "End date must be after start date.";
                return new JsonResult(new { errorMessage = "End date must be after start date." });
            }

            if (StartDate < DateTime.Now)
            {
                ErrorMessage = "Start date must be after today.";
                return new JsonResult(new { errorMessage = "Start date must be after today." });
            }
        

            try
            {
                PriceResult = projectManager.RentManager.CalculatePrice(user, Car.PricePerDay, StartDate, EndDate);
                return new JsonResult(new { price = PriceResult });
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in OnPostCalculatePrice: " + ex.Message);
                return new JsonResult(new { errorMessage = "An error occurred while calculating the price." });
            }
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

            if (StartDate < DateTime.Now)
            {
                ErrorMessage = "Start date must be after today.";
                return Page();
            }

            user = projectManager.PeopleManager.GetUser(User.Identity.Name);

            if (!projectManager.RentManager.IsCarAvailable(Car.Id, StartDate, EndDate))
            {
                ErrorMessage = "The car is already rented for the selected period.";
                return Page();
            }

            try
            {
                RentACar rentACar = new RentACar(user, Car, StartDate, EndDate, RentStatus.REQUESTED);
                if (projectManager.RentManager.RentACar(rentACar, out string errorMessage))
                {
                    PriceResult = projectManager.RentManager.CalculatePrice(user, Car.PricePerDay, StartDate, EndDate);
                    ErrorMessage = null;
                    return RedirectToPage("RentConfirmation", new { carId = Car.Id, Start = StartDate, End = EndDate, Price = PriceResult });
                }
                else
                {
                    Console.WriteLine("Error in OnPostRentCar: " + errorMessage);
                    ErrorMessage = errorMessage;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in OnPostRentCar: " + ex.Message);
                ErrorMessage = "An error occurred while renting the car.";
            }

            return Page();
        }
    }
}
