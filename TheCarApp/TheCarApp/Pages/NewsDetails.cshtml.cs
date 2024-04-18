using Entity_Layer;
using EntityLayout;
using ManagerLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheCarApp.Pages
{
    [Authorize]
    public class NewsDetailsModel : PageModel
    {
        private ProjectManager projectManager = new ProjectManager(); // Assuming CarManager has the necessary methods

        public CarNews news { get; set; }

        public NewsDetailsModel()
        {
        }

        public void OnGet(int NewsId)
        {
            news = projectManager.newsManager.GetNewsById(NewsId); // Method to get the car details
            if (news == null)
            {
                RedirectToPage("/NotFound");
            }
        }
    }
}
