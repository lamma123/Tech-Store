using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SE1726_NET_SWP391_Group5.Models;


namespace SE1726_NET_SWP391_Group5.Pages.PostController
{
    public class GuestPostModel : PageModel
    {
        private readonly SWP391Context context;

        public GuestPostModel(SWP391Context db)
        {
            context = db;
        }
        [BindProperty]
        public List<Post> Posts { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Lấy danh sách bài viết từ cơ sở dữ liệu
            Posts = context.Posts.Where(p => p.EmployeeId != null && p.EmployeeId != 0).ToList();
            return Page();
        }
    }
}
