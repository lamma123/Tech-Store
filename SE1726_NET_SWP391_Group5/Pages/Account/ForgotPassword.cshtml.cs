using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SE1726_NET_SWP391_Group5.Helpers;
using SE1726_NET_SWP391_Group5.Models;

namespace SE1726_NET_SWP391_Group5.Pages.Account
{
    public class ForgotPasswordModel : PageModel
    {
        private readonly SWP391Context _db;
        public ForgotPasswordModel(SWP391Context db)
        {
            _db = db;
        }
        [BindProperty]
        public string email { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (String.IsNullOrEmpty(email))
            {
                TempData["msg"] = "Please enter your email to get password!";
                return Page();
            }

            var account = await _db.Accounts.FirstOrDefaultAsync(a => a.Email.Equals(email));
            if (account == null)
            {
                TempData["msg"] = "Not found email, please check again!";
                return Page();
            }
            String password = account.Password;

            string bodyMail = "Your password is: " + password + "";

            var body = bodyMail;
            SendPasswordMail.SendMail(email, body);
            TempData["msg"] = "Please check you email!";
            return Page();

        }
    }
}
