using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SE1726_NET_SWP391_Group5.Models;
using System.Text.Json;

namespace SE1726_NET_SWP391_Group5.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly SWP391Context _db;
        public LoginModel(SWP391Context db)
        {
            _db = db;
        }
        [BindProperty]
        public Models.Account Account { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            var member = await _db.Accounts.SingleOrDefaultAsync(a => a.Email.Equals(Account.Email) && a.Password.Equals(Account.Password));
            if (member != null)
            {
                if (member.Role == 1)
                {
                    HttpContext.Session.SetString("customer", JsonSerializer.Serialize(member));
                    return RedirectToPage("/Index");
                }
                if (member.Role == 2)
                {
                    HttpContext.Session.SetString("marketing", JsonSerializer.Serialize(member));
                    return RedirectToPage("/MarketingStaff/Voucher");
                }
                if (member.Role == 3)
                {
                    HttpContext.Session.SetString("seller", JsonSerializer.Serialize(member));
                    return RedirectToPage("/Seller/Product/Manage");
                }
                if (member.Role == 4)
                {
                    HttpContext.Session.SetString("shipper", JsonSerializer.Serialize(member));
                    return RedirectToPage("/Shipper/Order/List");
                }
                if (member.Role == 5)
                {
                    HttpContext.Session.SetString("admin", JsonSerializer.Serialize(member));
                    return RedirectToPage("/Admin/ManagerEmployees");
                }
            }
            else
            {
                TempData["msg"] = "Email or Password invalid";
                return Page();
            }
            return Page();
        }
    }
}
