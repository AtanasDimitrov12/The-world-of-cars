using Entity_Layer;
using EntityLayout;
using EntityLayout.Enums;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace TheCarApp.Pages
{
    public class MarketPlaceModel : PageModel
    {
        public List<Car> Cars = new List<Car>(); 

        public void OnGet()
        {
            Cars.Add(new SpecificCar("Audi", "A6", 2000, 140000, "Diesel", 2000, 250, "Automatic", "Blue", 15000));
            Cars.Add(new SpecificCar("BMW", "230", 2010, 140000, "Petrol", 2500, 300, "Automatic", "Blue", 20000));
            Cars.Add(new SpecificCar("Audi", "A6", 2000, 140000, "Diesel", 2000, 250, "Automatic", "Blue", 15000));
            Cars.Add(new SpecificCar("BMW", "230", 2010, 140000, "Petrol", 2500, 300, "Automatic", "Blue", 20000));
            Cars.Add(new SpecificCar("Audi", "A6", 2000, 140000, "Diesel", 2000, 250, "Automatic", "Blue", 15000));
            Cars.Add(new SpecificCar("BMW", "230", 2010, 140000, "Petrol", 2500, 300, "Automatic", "Blue", 20000));
        }
    }
}
