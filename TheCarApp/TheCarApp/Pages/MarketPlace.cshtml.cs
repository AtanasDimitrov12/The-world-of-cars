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
        public DateTime date = DateTime.Now;

        public void OnGet()
        {
            Cars.Add(new Car(1, "Audi", "A6", date, 140000, "Diesel", 2000, 250, "Automatic", "Blue", "VIN", "Description", 150, CarStatus.AVAILABLE, 5, "2/3"));
            Cars.Add(new Car(2, "BMW", "230", date, 140000, "Petrol", 2500, 300, "Automatic", "Blue", "VIN", "Description", 150, CarStatus.AVAILABLE, 5, "4/5"));
            Cars.Add(new Car(3, "Audi", "A6", date, 140000, "Diesel", 2000, 250, "Automatic", "Blue", "VIN", "Description", 150, CarStatus.AVAILABLE, 5, "2/3"));
            Cars.Add(new Car(4, "BMW", "230", date, 140000, "Petrol", 2500, 300, "Automatic", "Blue", "VIN", "Description", 150, CarStatus.AVAILABLE, 5, "4/5"));
            Cars.Add(new Car(5, "Audi", "A6", date, 140000, "Diesel", 2000, 250, "Automatic", "Blue", "VIN", "Description", 150, CarStatus.AVAILABLE, 5, "2/3"));
            Cars.Add(new Car(6, "BMW", "230", date, 140000, "Petrol", 2500, 300, "Automatic", "Blue", "VIN", "Description", 150, CarStatus.AVAILABLE, 5, "4/5"));
        }
    }
}
