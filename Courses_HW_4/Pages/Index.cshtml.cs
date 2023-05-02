using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Courses_HW_4.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        public static bool Error { get; set; }
        public static string ErrorMessage { get; set; } = "";
        public static bool RemoveCookiesButtonDisabled { get; set; } = true;
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            RemoveCookiesButtonDisabled = Convert.ToBoolean(Request.Cookies["RemoveCookiesButtonDisabled"]);
        }
        public IActionResult OnPostRedirectToMain()
        {
            string name = Request.Form["Name"];
            string email = Request.Form["Email"];
            if(string.IsNullOrWhiteSpace(name) || !Regex.IsMatch(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
            {
                Error = true;
                ErrorMessage = "Field name or email was empty or email wasnt in correct format :(";
                return Page();
            }
            Error = false;
            Response.Cookies.Append("name", name);
            Response.Cookies.Append("email", email);
            Response.Cookies.Append("RemoveCookiesButtonDisabled", "false");
            RemoveCookiesButtonDisabled = false;
            return RedirectToPage("Main");
        }
        public void OnPostClearCookies()
        {
            Response.Cookies.Delete("name");
            Response.Cookies.Delete("email");
            Response.Cookies.Append("RemoveCookiesButtonDisabled", "true");
            RemoveCookiesButtonDisabled = true;
        }
    }
}