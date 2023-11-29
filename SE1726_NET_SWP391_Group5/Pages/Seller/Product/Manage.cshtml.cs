using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SE1726_NET_SWP391_Group5.Models;

namespace SE1726_NET_SWP391_Group5.Pages.Seller.Product
{
    public class ManageModel : PageModel
    {
        private readonly SWP391Context db = new SWP391Context();

        [BindProperty]
        public List<Models.Product> products { set; get; }
        [BindProperty]
        public List<Category> categories { set; get; }
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }
        [BindProperty]
        public string? mesString { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }

        public ManageModel(SWP391Context db)
        {
            this.db = db;
        }


        public async Task<IActionResult> OnGetAsync(int? cid, string? mes, int? pageNumber)
        {
            if (!String.IsNullOrEmpty(mes))
                mesString = mes;
            else
            {
                mesString = null;
            }

            categories = await db.Categories.ToListAsync();

            var prod = from m in db.Products select m;

            if (HttpContext.Session.GetString("seller") != null)
            {

                PageSize = 8;
                PageIndex = pageNumber ?? 1;
                TotalItems = await prod.CountAsync();



                if (!string.IsNullOrEmpty(SearchString))
                {
                    prod = prod.Where(s => s.ProductName.Contains(SearchString));
                }

                if (cid != null)
                {
                    prod = prod.Where(s => s.Category.CategoryId == cid);
                }

                if (!string.IsNullOrEmpty(SearchString) && cid != null)
                {
                    prod = prod.Where(s => s.Category.CategoryId == cid && s.Category.CategoryId == cid);
                }

                products = await prod
                    .Skip((PageIndex - 1) * PageSize)
                    .Take(PageSize)
                    .ToListAsync();
                return Page();
            }
            return RedirectToPage("/Account/Login");
        }
    }
}
