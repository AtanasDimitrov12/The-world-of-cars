using Entity_Layer;
using ManagerLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheCarApp.Pages
{
    [Authorize]
    public class CarNewsModel : PageModel
    {
        public List<CarNews> News;
        public ProjectManager projectManager = new ProjectManager();

        public void OnGet()
        {
            News = projectManager.NewsManager.news;
        }
    }
}
