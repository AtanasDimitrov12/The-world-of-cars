using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DTO;
using Manager_Layer;
using Microsoft.AspNetCore.Authorization;
using ManagerLayer;
using DTO.Enums;

namespace TheCarApp.Pages
{
    [Authorize]
    public class RentACarPageModel : PageModel
    {
        private readonly ProjectManager projectManager;

        public CarDTO Car { get; set; }
        public UserDTO user { get; set; }
        public string UserEmail { get; set; }
        public decimal PriceResult { get; set; }
        public string ErrorMessage { get; set; }
        public List<RentACarDTO> RentedPeriods { get; set; }

        public RentACarPageModel(ProjectManager _projectManager)
        {
            projectManager = _projectManager;
        }

        public async Task<IActionResult> OnGet(int carId)
        {
            Car = projectManager.CarManager.GetCarById(carId);

            if (Car == null)
            {
                return RedirectToPage("/NotFound");
            }
            else
            {
                await projectManager.CarManager.RecordCarViewAsync(carId);
                RentedPeriods = projectManager.RentManager.GetRentedPeriods(carId);
            }
            UserEmail = User.Identity.Name;
            user = projectManager.UserManager.FindUserByEmail(UserEmail);

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

            if (StartDate < DateTime.Now.Date)
            {
                ErrorMessage = "Start date must be today or later.";
                return new JsonResult(new { errorMessage = "Start date must be today or later." });
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

        public async Task<IActionResult> OnPostRentCar(DateTime StartDate, DateTime EndDate)
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

            if (StartDate < DateTime.Now.Date)
            {
                ErrorMessage = "Start date must be today or later.";
                return Page();
            }

            user = projectManager.UserManager.FindUserByEmail(User.Identity.Name);

            if (!projectManager.RentManager.IsCarAvailable(Car.Id, StartDate, EndDate))
            {
                ErrorMessage = "The car is already rented for the selected period.";
                return Page();
            }

            try
            {
                RentACarDTO rentACar = new RentACarDTO() 
                {
                    UserId = user.Id,
                    CarId = Car.Id,
                    StartDate = StartDate,
                    EndDate = EndDate,
                    Status = RentStatus.REQUESTED.ToString(),
                };

                (bool Response, string errorMessage) = await projectManager.RentManager.RentACarAsync(rentACar);
                if (Response)
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
