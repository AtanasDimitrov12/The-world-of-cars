using Entity_Layer.Enums;
using EntityLayout;
using Manager_Layer;
using ManagerLayer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TheCarApp.Pages
{
    [Authorize]
    public class MarketPlaceModel : PageModel
    {
        public List<Car> Cars;
        public ProjectManager projectManager;
        public List<string> ColorOptions { get; set; }

        public MarketPlaceModel(ProjectManager pm)
        {
            projectManager = pm;
            ColorOptions = Enum.GetValues(typeof(Colors))
                               .Cast<Colors>()
                               .Select(color => color.ToString().Substring(0, 1) + color.ToString().Substring(1).ToLower())
                               .ToList();
        }

        public void OnGet(string sort, int? minHP, int? maxHP, DateTime? minYear, DateTime? maxYear, decimal? minPrice, decimal? maxPrice, string color)
        {
            Cars = projectManager.CarManager.GetCars();

            if (minHP.HasValue) Cars = Cars.Where(car => car.HorsePower >= minHP.Value).ToList();
            if (maxHP.HasValue) Cars = Cars.Where(car => car.HorsePower <= maxHP.Value).ToList();
            if (minYear.HasValue) Cars = Cars.Where(car => car.FirstRegistration >= minYear.Value).ToList();
            if (maxYear.HasValue) Cars = Cars.Where(car => car.FirstRegistration <= maxYear.Value).ToList();
            if (minPrice.HasValue) Cars = Cars.Where(car => car.PricePerDay >= minPrice.Value).ToList();
            if (maxPrice.HasValue) Cars = Cars.Where(car => car.PricePerDay <= maxPrice.Value).ToList();
            if (!string.IsNullOrEmpty(color) && color != "Any")
            {
                string normalizedColor = color.ToUpper();
                Cars = Cars.Where(car => car.Color == normalizedColor).ToList();
            }

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
                case "date_asc":
                    Cars = Cars.OrderBy(car => car.FirstRegistration).ToList();
                    break;
                case "date_desc":
                    Cars = Cars.OrderByDescending(car => car.FirstRegistration).ToList();
                    break;
                default:
                    break;
            }
        }
    }
}
