using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SE1726_NET_SWP391_Group5.Models;

namespace SE1726_NET_SWP391_Group5.Pages
{
    public class IndexModel : PageModel
    {
        private readonly SWP391Context context;
        [BindProperty]
        public List<Category> Categories { get; set; }
        [BindProperty]
        public List<Models.Product> Hot { get; set; }

        public IndexModel(SWP391Context context)
        {
            this.context = context;
        }


        public async Task<IActionResult> OnGetAsync()
        {
            Categories = await context.Categories.ToListAsync();
            Hot = await context.Products.Where(p => p.UnitInStock > 0).OrderByDescending(p => p.ProductId).Take(12).ToListAsync();
            return Page();
        }
    }
}
