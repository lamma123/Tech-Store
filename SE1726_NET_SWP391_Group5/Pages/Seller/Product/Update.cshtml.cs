using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using SE1726_NET_SWP391_Group5.Models;

namespace SE1726_NET_SWP391_Group5.Pages.Seller.Product
{
    public class UpdateModel : PageModel
    {
        private readonly SWP391Context db;
        [BindProperty]
        public Models.Product product { get; set; }
        public UpdateModel(SWP391Context db)
        {
            this.db = db;

        }
        public async Task<ActionResult> OnGetAsync(int? id)
        {
            if (HttpContext.Session.GetString("seller") != null)
            {
                if (id == null)
                {
                    return RedirectToPage("/Error");
                }
                else
                {
                    product = db.Products.Where(e => e.ProductId == id).SingleOrDefault();
                    ViewData["CategoriesId"] = new SelectList(db.Categories.ToList(), "CategoryId", "CategoryName");
                    if (product == null)
                    {
                        return RedirectToPage("/Error");
                    }

                    return Page();
                }
            }
            return RedirectToPage("/Account/Login");
        }
        public async Task<ActionResult> OnPostAsync(int? id)
        {
            if (HttpContext.Session.GetString("seller") != null)
            {
                if (id == null)
                    return RedirectToPage("/Error");
                var prod = await db.Products.FindAsync(id);
                if (prod == null)
                    return BadRequest();

                prod.ProductName = product.ProductName;
                prod.CategoryId = product.CategoryId;
                prod.UnitPrice = product.UnitPrice;
                prod.UnitInStock = product.UnitInStock;
                prod.Description = product.Description;
                await db.SaveChangesAsync();
                return RedirectToPage("Manage");
            }
            return RedirectToPage("/Account/Login");
        }
    }
}
