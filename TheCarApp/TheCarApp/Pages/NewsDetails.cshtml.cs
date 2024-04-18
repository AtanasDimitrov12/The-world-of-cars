using Entity_Layer;
using EntityLayout;
using ManagerLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheCarApp.Pages
{
    [Authorize]
    public class NewsDetailsModel : PageModel
    {
        public ProjectManager projectManager { get; set; }
        public CarNews news { get; set; }

        [BindProperty]
        public Comment NewComment { get; set; }

        public NewsDetailsModel()
        {
            projectManager = new ProjectManager(); // Assuming CarManager has the necessary methods
            NewComment = new Comment();
        }

        public void OnGet(int NewsId)
        {
            news = projectManager.newsManager.GetNewsById(NewsId); // Method to get the car details
            if (news == null)
            {
                RedirectToPage("/NotFound");
            }
        }

        public async Task<IActionResult> OnPostAddComment(int NewsId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Initialize news in the POST method as well
            news = projectManager.newsManager.GetNewsById(NewsId);

            // Check if news exists before proceeding
            if (news == null)
            {
                return RedirectToPage("/NotFound");
            }

            
            DateTime date = DateTime.Now;
            var user = projectManager.peopleManager.GetUser(User.Identity.Name);

            if (user != null && NewComment.Message != null)
            {
                NewComment.UserId = user.Id;
                NewComment.Date = date;
                projectManager.commentsManager.AddComment(news, NewComment);
            }

            
            return RedirectToPage(new { NewsId = NewsId });
        }

    }
}

