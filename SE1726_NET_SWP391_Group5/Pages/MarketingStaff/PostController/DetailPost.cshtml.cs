using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SE1726_NET_SWP391_Group5.Models;
using System.Text.RegularExpressions;

namespace SE1726_NET_SWP391_Group5.Pages.PostController
{
    public class DetailPostModel : PageModel
    {
        private readonly SWP391Context context;

        public DetailPostModel(SWP391Context db)
        {
            context = db;
        }

        public Post Post { get; set; }
        public string ImageUrl { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await context.Posts.FirstOrDefaultAsync(m => m.PostId == id);

            if (Post == null)
            {
                return NotFound();
            }
            


            return Page();
        }
       
    }
}

