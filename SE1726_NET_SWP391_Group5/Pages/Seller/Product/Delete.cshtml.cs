using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SE1726_NET_SWP391_Group5.Models;

namespace SE1726_NET_SWP391_Group5.Pages.Seller.Product
{
    public class DeleteModel : PageModel
    {
        private readonly SWP391Context db = new SWP391Context();

        [BindProperty]
        public string? mesString { get; set; }


        public DeleteModel(SWP391Context db)
        {
            this.db = db;
        }

        public async Task<IActionResult> OnGetAsync(int? idDelete)
        {
            if (HttpContext.Session.GetString("seller") != null)
            {
                if (idDelete == null)
                {
                    return RedirectToPage("./Manage");
                }
                else
                {
                    var prod = await db.Products.FindAsync(idDelete);
                    if (prod == null)
                        return BadRequest();
                    else
                    {
                        var listOrderdetail = await db.OrderDetails.Where(x => x.ProductId == idDelete).ToListAsync();
                        if (listOrderdetail.Count > 0)
                        {
                            foreach (var item in listOrderdetail)
                            {
                                db.OrderDetails.Remove(item);
                            }
                        }
                        mesString = "Product has been removed!";
                        db.Products.Remove(prod);
                        await db.SaveChangesAsync();
                        mesString = "Product have been removed!";
                        return Redirect("./Manage");
                    }
                }
            }
            return RedirectToPage("/Account/Login");
        }
    }
}
