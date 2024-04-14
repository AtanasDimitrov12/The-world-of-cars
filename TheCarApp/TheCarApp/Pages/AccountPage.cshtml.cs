using Entity_Layer;
using Manager_Layer;
using ManagerLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheCarApp.Pages
{
    public class AccountPageModel : PageModel
    {
        public User user { get; set; }
        public List<RentACar> rentals { get; set; }
        public void OnGet()
        {
            user = new User();
            user.email = "example@gmail.com";
            user.CreatedOn = DateTime.Now;
            user.Username = "admin";

            //rentals.Add();
            
        }
    }
}


//using Microsoft.AspNetCore.Mvc;
//using Microsoft.AspNetCore.Mvc.RazorPages;
//using ManagerLayer;
//using Entity_Layer;

//public class AccountModel : PageModel
//{
//    private readonly ProjectManager _projectManager;
//    public User User { get; set; }
//    public List<Rental> Rentals { get; set; }

//    public AccountModel(ProjectManager projectManager)
//    {
//        _projectManager = projectManager;
//    }

//    public void OnGet()
//    {
//        // Assuming we have a method to get user and rental data
//        User = _projectManager.peopleManager.GetUser(User.Identity.Name); // Adjust as per your user retrieval logic
//        Rentals = _projectManager.rentManager.GetRentalsForUser(User.Id);
//    }
//}
