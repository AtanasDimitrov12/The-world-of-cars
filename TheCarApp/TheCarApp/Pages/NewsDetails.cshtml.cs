using DTO;
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
        public CarNewsDTO news { get; set; }

        [BindProperty]
        public CommentDTO NewComment { get; set; }

        public NewsDetailsModel(ProjectManager pm)
        {
            projectManager = pm; 
            NewComment = new CommentDTO();
        }

        public void OnGet(int NewsId)
        {
            news = projectManager.NewsManager.GetNewsById(NewsId);
            if (news == null)
            {
                RedirectToPage("/NotFound");
            }
            ViewData["NewsId"] = news.Id; // Add this line
        }


        public async Task<IActionResult> OnPostAddComment(int NewsId)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            news = projectManager.NewsManager.GetNewsById(NewsId);

            if (news == null)
            {
                return RedirectToPage("/NotFound");
            }

            
            DateTime date = DateTime.Now;
            var user = projectManager.UserManager.FindUserByEmail(User.Identity.Name);

            if (user != null && NewComment.Content != null)
            {
                NewComment.UserId = user.Id;
                NewComment.Date = date;
                await projectManager.CommentsManager.AddCommentAsync(news, NewComment); // Display error message
            }

            
            return RedirectToPage(new { NewsId = NewsId });
        }

    }
}

