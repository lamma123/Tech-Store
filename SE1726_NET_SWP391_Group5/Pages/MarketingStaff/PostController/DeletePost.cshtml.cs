using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SE1726_NET_SWP391_Group5.Models;
using System.Threading.Tasks;

namespace SE1726_NET_SWP391_Group5.Pages.PostController
{
    public class DeletePostModel : PageModel
    {
        private readonly SWP391Context _db;

        public DeletePostModel(SWP391Context db)
        {
            _db = db;
        }

        [BindProperty]
        public Post Post { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await _db.Posts.FirstOrDefaultAsync(m => m.PostId == id);

            if (Post == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await _db.Posts.FindAsync(id);

            if (Post != null)
            {
                _db.Posts.Remove(Post);
                await _db.SaveChangesAsync();
            }

            return RedirectToPage("/MarketingStaff/PostController/Post");
        }
    }
}