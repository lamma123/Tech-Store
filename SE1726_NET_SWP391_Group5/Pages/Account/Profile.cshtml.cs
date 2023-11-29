using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SE1726_NET_SWP391_Group5.Models;
using System.Text.Json;

namespace SE1726_NET_SWP391_Group5.Pages.Admin
{
    public class ProfileModel : PageModel
    {
        private readonly SWP391Context context;

        [BindProperty]
        public Models.Account account { get; set; }
        public Models.Account accountAd { get; set; }
        public ProfileModel(SWP391Context context)
        {
            this.context = context;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            if (HttpContext.Session.GetString("customer") == null)
            {
                return Redirect("/Account/Login");
            }
            account = JsonSerializer.Deserialize<Models.Account>(HttpContext.Session.GetString("customer"));
            if (account == null)
            {
                return RedirectToPage("/Error");
            }
            else
            {
                account.Customer = await context.Customers.FirstOrDefaultAsync(c => c.CustomerId == account.CustomerId);
            }

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                Models.Account auth = JsonSerializer.Deserialize<Models.Account>(HttpContext.Session.GetString("customer"));

                var acc = await context.Accounts.FirstOrDefaultAsync(a => a.AccountId == auth.AccountId);

                if (acc.CustomerId != null)

                    acc.Customer = await context.Customers.FirstOrDefaultAsync(c => c.CustomerId == acc.CustomerId);

                //acc.Email = Auth.Email;
                acc.Customer.Phone = account.Customer.Phone;
                acc.Customer.Region = account.Customer.Region;
                acc.Customer.Country = account.Customer.Country;
                acc.Customer.City = account.Customer.City;
                acc.Customer.Address = account.Customer.Address;
                acc.Password = account.Password;
                await context.SaveChangesAsync();
                ViewData["success"] = "Update Successfull";
                return Page();
            }
            catch (Exception e)
            {

                ViewData["fail"] = e.Message;
                return Page();
            }

        }
    }
}
