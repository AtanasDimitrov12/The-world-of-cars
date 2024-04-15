using Entity_Layer.Enums;
using EntityLayout;
using EntityLayout;
using Manager_Layer;
using ManagerLayer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace TheCarApp.Pages
{
    [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
    public class MarketPlaceModel : PageModel
    {
        public List<Car> Cars;
        public ProjectManager projectManager = new ProjectManager();

        public void OnGet()
        {
            Cars = projectManager.carManager.GetCars(); // trqbva da ima samo kolite koito imat Status = Available 
        }
    }
}
