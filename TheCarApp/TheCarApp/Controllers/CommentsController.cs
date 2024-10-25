using Microsoft.AspNetCore.Mvc;
using TheCarApp.Models;
using System.Linq;
using ManagerLayer;

namespace TheCarApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ProjectManager _projectManager;

        public CommentsController(ProjectManager projectManager)
        {
            _projectManager = projectManager;
        }

        [HttpGet("{newsId}")]
        public IActionResult GetComments(int newsId, int page = 1, int pageSize = 10)
        {
            var news = _projectManager.NewsManager.GetNewsById(newsId);
            if (news == null)
            {
                return NotFound();
            }

            var sortedComments = news.Comments.OrderByDescending(c => c.CommentDate);

            var comments = sortedComments
                               .Skip((page - 1) * pageSize)
                               .Take(pageSize)
                               .Select(comment => new
                               {
                                   comment.Content,
                                   comment.CommentDate,
                                   userName = _projectManager.UserManager.GetUserNameById(comment.UserId),
                                   profilePic = _projectManager.UserManager.GetProfilePicPathById(comment.UserId)
                               });

            
            var hasMore = sortedComments.Count() > page * pageSize;

            return Ok(new
            {
                comments,
                hasMore
            });
        }
    }
}
