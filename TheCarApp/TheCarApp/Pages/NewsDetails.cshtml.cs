using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TheCarApp.Pages
{
    [Authorize]
    public class NewsDetailsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
