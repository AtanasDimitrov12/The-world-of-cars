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
        public List<CarNews> News { get; set; }
        public ProjectManager projectManager;
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public string SearchQuery { get; set; }
        public bool AllNewsDisplayed { get; set; }

        public CarNewsModel(ProjectManager pm)
        {
            projectManager = pm;
        }

        public void OnGet(int pageNumber = 1, string searchQuery = "")
        {
            SearchQuery = searchQuery;
            var allNews = string.IsNullOrEmpty(searchQuery)
                ? projectManager.NewsManager.news
                : projectManager.NewsManager.news
                    .Where(n => n.Title.Contains(searchQuery, StringComparison.OrdinalIgnoreCase) ||
                                n.NewsDescription.Contains(searchQuery, StringComparison.OrdinalIgnoreCase))
                    .ToList();

            int newsPerPage = 6;
            TotalPages = (int)Math.Ceiling(allNews.Count / (double)newsPerPage);
            CurrentPage = pageNumber;
            News = allNews.Skip((CurrentPage - 1) * newsPerPage).Take(newsPerPage).ToList();
            AllNewsDisplayed = News.Count < allNews.Count;
        }
    }
}
