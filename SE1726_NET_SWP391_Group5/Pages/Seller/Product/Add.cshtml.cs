using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SE1726_NET_SWP391_Group5.Models;

namespace SE1726_NET_SWP391_Group5.Pages.Seller.Product
{
    public class AddModel : PageModel
    {
        private readonly SWP391Context db;
        [BindProperty]
        public Models.Product product { get; set; }
        public AddModel(SWP391Context db)
        {
            this.db = db;

        }
        public async Task<ActionResult> OnGetAsync()
        {
            if (HttpContext.Session.GetString("seller") != null)
            {
                ViewData["CategoriesId"] = new SelectList(db.Categories.ToList(), "CategoryId", "CategoryName");
                return Page();
            }
            return RedirectToPage("../Account/Login");

        }

        public async Task<ActionResult> OnPostAsync()
        {
            //if (ModelState.IsValid)
            //{
            if (HttpContext.Session.GetString("seller") != null)
            {
                Console.WriteLine(product.Description);
                //Save data into DB
                db.Products.Add(product);
                await db.SaveChangesAsync();
                return RedirectToPage("Manage");


            }
            return RedirectToPage("../Account/Login");
        }
    }
}
