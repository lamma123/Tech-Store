using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SE1726_NET_SWP391_Group5.Models;
using System.Text.Json;

namespace SE1726_NET_SWP391_Group5.Pages.Admin
{
    public class ManagerEmployeesModel : PageModel
    {
        private readonly SWP391Context context = new SWP391Context();
        [BindProperty]
        public Models.Account account { get; set; }
        [BindProperty]
        public List<Emloyee> employees { get; set; }


        public ManagerEmployeesModel(SWP391Context context)
        {
            this.context = context;
        }
        public async Task<IActionResult> OnGetAsync()
        {
            //if (HttpContext.Session.GetString("admin") == null)
            //{
            //    return Redirect("/Account/Login");
            //}
            //account = JsonSerializer.Deserialize<Models.Account>(HttpContext.Session.GetString("admin"));
            //if (account == null)
            //{
            //    return RedirectToPage("/Error");
            //}
            employees = await context.Emloyees.ToListAsync();
            return Page();

        }

    }
}
