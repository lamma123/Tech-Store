using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SE1726_NET_SWP391_Group5.Models;
using System.Text;

namespace SE1726_NET_SWP391_Group5.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SWP391Context _db;
        public RegisterModel(SWP391Context db)
        {
            _db = db;
        }
        [BindProperty]
        public Models.Account Account { get; set; }
        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();
            var acc = await _db.Accounts.SingleOrDefaultAsync(a => a.Email.Equals(Account.Email));
            if (acc != null)
            {
                TempData["msg"] = "This email is exist";
                return Page();
            }
            var cust = new Customer()
            {
                CustomerId = RandomID(5),
                Name = Customer.Name,
                Address = Customer.Address,
                City = Customer.City,
                Region = Customer.Region,
                Country = Customer.Country,
                Phone = Customer.Phone,
            };
            var newAcc = new Models.Account()
            {
                Email = Account.Email,
                Password = Account.Password,
                CustomerId = cust.CustomerId,
                Role = 1,
            };
            await _db.Customers.AddAsync(cust);
            await _db.Accounts.AddAsync(newAcc);
            await _db.SaveChangesAsync();
            TempData["msg"] = "Register Successfully! Login to continue!!!";
            return RedirectToPage("Login");
        }
        private string RandomID(int length)
        {
            StringBuilder str_build = new StringBuilder();
            Random random = new Random();
            char letter;
            for (int i = 0; i < length; i++)
            {
                double flt = random.NextDouble();
                int shift = Convert.ToInt32(Math.Floor(25 * flt));
                letter = Convert.ToChar(shift + 65);
                str_build.Append(letter);
            }
            return str_build.ToString();
        }
    }
}
