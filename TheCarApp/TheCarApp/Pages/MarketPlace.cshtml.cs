using Entity_Layer.Enums;
using EntityLayout;
using EntityLayout;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace TheCarApp.Pages
{
    public class MarketPlaceModel : PageModel
    {
        public List<Car> Cars = new List<Car>(); 

        public void OnGet()
        {
            Cars.Add(new Car(1, "Audi", "A6", 2000, 140000, "Diesel", 2000, 250, "Automatic", "Blue", "VIN", "Description", 150, CarStatus.AVAILABLE));
            Cars.Add(new Car(2, "BMW", "230", 2010, 140000, "Petrol", 2500, 300, "Automatic", "Blue", "VIN", "Description", 150, CarStatus.AVAILABLE));
            Cars.Add(new Car(3, "Audi", "A6", 2000, 140000, "Diesel", 2000, 250, "Automatic", "Blue", "VIN", "Description", 150, CarStatus.AVAILABLE));
            Cars.Add(new Car(4, "BMW", "230", 2010, 140000, "Petrol", 2500, 300, "Automatic", "Blue", "VIN", "Description", 150, CarStatus.AVAILABLE));
            Cars.Add(new Car(5, "Audi", "A6", 2000, 140000, "Diesel", 2000, 250, "Automatic", "Blue", "VIN", "Description", 150, CarStatus.AVAILABLE));
            Cars.Add(new Car(6, "BMW", "230", 2010, 140000, "Petrol", 2500, 300, "Automatic", "Blue", "VIN", "Description", 150, CarStatus.AVAILABLE));
        }
    }
}
