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
        private ProjectManager projectManager = new ProjectManager(); 

        public Car Car { get; set; }

        public RentACarPageModel()
        {
        }

        public void OnGet(int carId)
        {
            Car = projectManager.carManager.GetCarById(carId); 
            if (Car == null)
            {
                RedirectToPage("/NotFound");
            }
        }
    }
}
