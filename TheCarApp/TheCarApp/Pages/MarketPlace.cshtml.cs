using Entity_Layer.Enums;
using EntityLayout;
using Manager_Layer;
using ManagerLayer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;

namespace TheCarApp.Pages
{
    [Authorize]
    public class MarketPlaceModel : PageModel
    {
        public List<Car> Cars;
        public ProjectManager projectManager = new ProjectManager();
        public List<string> Colors { get; set; } = new List<string>() { "Black", "Blue", "White" };

        public void OnGet(string sort, int? minHP, int? maxHP, DateTime? minYear, DateTime? maxYear, decimal? minPrice, decimal? maxPrice, string color)
        {
            Cars = projectManager.CarManager.GetCars();

            if (minHP.HasValue) Cars = Cars.Where(car => car.HorsePower >= minHP.Value).ToList();
            if (maxHP.HasValue) Cars = Cars.Where(car => car.HorsePower <= maxHP.Value).ToList();
            if (minYear.HasValue) Cars = Cars.Where(car => car.FirstRegistration >= minYear.Value).ToList();
            if (maxYear.HasValue) Cars = Cars.Where(car => car.FirstRegistration <= maxYear.Value).ToList();
            if (minPrice.HasValue) Cars = Cars.Where(car => car.PricePerDay >= minPrice.Value).ToList();
            if (maxPrice.HasValue) Cars = Cars.Where(car => car.PricePerDay <= maxPrice.Value).ToList();
            if (!string.IsNullOrEmpty(color) && color != "Any") Cars = Cars.Where(car => car.Color == color).ToList();

            
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
                    break;
            }
        }
    }
}