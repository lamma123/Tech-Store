using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SE1726_NET_SWP391_Group5.Pages.Account
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Remove("admin");
            HttpContext.Session.Remove("seller");
            HttpContext.Session.Remove("marketing");
            HttpContext.Session.Remove("customer");
            HttpContext.Session.Remove("shipper");
            return RedirectToPage("/Index");
        }
    }
}
