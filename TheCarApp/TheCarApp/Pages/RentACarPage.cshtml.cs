using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity_Layer; // Ensure this namespace correctly references where your Car and other entities are defined
using Manager_Layer;
using Microsoft.AspNetCore.Authorization; // This should reference your service layer or business logic
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
        private ProjectManager projectManager = new ProjectManager(); // Assuming CarManager has the necessary methods

        public Car Car { get; set; }

        public RentACarPageModel()
        {
        }

        public void OnGet(int carId)
        {
            Car = projectManager.carManager.GetCarById(carId); // Method to get the car details
            if (Car == null)
            {
                RedirectToPage("/NotFound");
            }
        }
    }
}
