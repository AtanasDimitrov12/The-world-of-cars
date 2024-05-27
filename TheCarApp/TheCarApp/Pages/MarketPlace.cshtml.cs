using Entity_Layer.Enums;
using EntityLayout;
using Manager_Layer;
using ManagerLayer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace TheCarApp.Pages
{
    [Authorize]
    public class MarketPlaceModel : PageModel
    {
        public List<Car> Cars;
        public ProjectManager projectManager = new ProjectManager();

        public void OnGet(string sort)
        {
            Cars = projectManager.CarManager.GetCars().Where(car => car.CarStatus == CarStatus.AVAILABLE).ToList();

            switch (sort)
            {
                case "views_asc":
                    Cars = Cars.OrderBy(car => car.Views).ToList();
                    break;
                case "views_desc":
                    Cars = Cars.OrderByDescending(car => car.Views).ToList();
                    break;
                case "price_asc":
                    Cars = Cars.OrderBy(car => car.PricePerDay).ToList();
                    break;
                case "price_desc":
                    Cars = Cars.OrderByDescending(car => car.PricePerDay).ToList();
                    break;
                default:
                    // Default sorting logic if any
                    break;
            }
        }
    }
}

