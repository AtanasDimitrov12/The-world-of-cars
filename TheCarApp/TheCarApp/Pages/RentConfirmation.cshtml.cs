using EntityLayout;
using InterfaceLayer;
using Manager_Layer;
using ManagerLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheCarApp.Models;

namespace TheCarApp.Pages
{
    public class RentConfirmationModel : PageModel
    {
        private readonly ICarManager _carManager;

        public RentConfirmationModel(ProjectManager _projectManager)
        {
            _carManager = _projectManager.CarManager;
        }

        public Car Car { get; set; }
        public DateTime RentalStartDate { get; set; }
        public DateTime RentalEndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public RentACar rent { get; set; }

        public void OnGet(int carId, RentACar rent)
        {
            this.rent = rent;
            Car = _carManager.GetCarById(carId);;
            RentalStartDate = rent.StartDate;
            RentalEndDate = rent.ReturnDate;
            TotalPrice = rent.TotalPrice;
        }
    }
}
