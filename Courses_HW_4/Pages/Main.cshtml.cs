using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Courses_HW_4.Pages
{
    public class MainModel : PageModel
    {
        public string? Name { get; set; }
        public string? Email { get; set; }

        public void OnGet()
        {
            Name = Request.Cookies["name"];
            Email = Request.Cookies["email"];
        }
    }
}
